using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlaneController : ObstacleController
{
    GameObject planeFlipper;

    bool attacking;

    float min;
    float max;

    public float rotSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        min = transform.position.y - .3f;
        max = transform.position.y + .3f;
        
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
        playerController = player.GetComponent<PlayerController>();
        playerAnim = player.GetComponentInChildren<Animator>();
        planeFlipper = GameObject.FindGameObjectWithTag("PlaneFlipper");

        //Groan
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject == planeFlipper)
        {
            attacking = true;
            //StartCoroutine("Flip");
        }
    }

    private void Update()
    {
        DestroyAtEnd();
        anim.SetBool("Attacking", attacking);

        //Groan
        groanWave = GameObject.FindGameObjectWithTag("GroanWave");
    }

    private void FixedUpdate()
    {
        Attacking();
        Gliding();
    }

    void Attacking()
    {
        if (attacking == true)
        {
            rb.velocity = Vector2.left * rotSpeed;

        }
    }

    IEnumerator Flip()
    {
        float rotx = 0;
        while (transform.rotation.z > -360f)
        {
            transform.Rotate(0, 0, -rotSpeed);
            rotx += transform.rotation.z;
            Debug.Log(rotx);
            yield return null;
        }
        attacking = false;
    }

    void Gliding()
    {
        if (attacking == false)
        {
            rb.velocity = Vector2.left * speed;
            transform.position = new Vector2(transform.position.x, Mathf.SmoothStep(min, max, Mathf.PingPong(Time.time * 2f, 1)));
        }
    }
}
