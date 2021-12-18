using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : ObstacleController
{
    GameObject switchCollider;
    GameObject crouchLine;
    GameObject jumpLine;
    public GameObject[] childObs;

    bool preAttacking;
    bool attacking;

    public float slowSpeed;

    int dir;

    public AudioSource soundPlayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
        playerController = player.GetComponent<PlayerController>();
        playerAnim = player.GetComponentInChildren<Animator>();
        switchCollider = GameObject.FindGameObjectWithTag("SwitchCollider");
        crouchLine = GameObject.FindGameObjectWithTag("CrouchLine");
        jumpLine = GameObject.FindGameObjectWithTag("JumpLine");

        //Groan
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    private void Update()
    {
        Floating();
        PreAttacking();
        Attacking();
        DestroyAtEnd();

        //Groan
        groanWave = GameObject.FindGameObjectWithTag("GroanWave");
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            PlayerController.hit = true;
            SurivialPlayerController.hit = true;
            hit = true;
            //StartCoroutine("FadeOut");
            col.enabled = false;
            anim.SetTrigger("hit");
            foreach(GameObject child in childObs)
            {
                Destroy(child);
            }
        }

        if (other.gameObject == switchCollider)
        {
            preAttacking = true;
            dir = Random.Range(0, 2);
            soundPlayer.pitch += .1f;
        }

        if(other.gameObject == crouchLine || other.gameObject == jumpLine)
        {
            if(preAttacking == true)
            {
                attacking = true;
                preAttacking = false;
            }
        }

        //Groan
        if (other.gameObject == groanWave)
        {
            Instantiate(screenSpatter, new Vector2(Random.Range(mainCamera.gameObject.transform.position.x - 1.2f, mainCamera.gameObject.transform.position.x + 1.2f), Random.Range(-.2f, .2f)), new Quaternion(0f, 0f, Random.Range(0, 360), 1), mainCanvas.transform);
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity, mainCamera.transform);
            Destroy(gameObject);
        }
    }
    void Attacking()
    {
        if (attacking == true)
        {
            rb.velocity = Vector2.left * speed;
        }
    }

    void Swoop()
    {
        if (attacking == false)
        {
            rb.velocity = Vector2.down * slowSpeed; ;
        }
    }

    void PreAttacking()
    {
        if(preAttacking == true)
        {
            if (dir == 0)
            {
                rb.velocity = new Vector2(-1 * (speed / 3), 1 * (speed / 3));
            }
            else
            {
                rb.velocity = new Vector2(-1 * (speed / 3), -1 * (speed / 3));
            }
        } 
    }

    void Floating()
    {
        if(attacking == false && preAttacking == false)
        {           
            rb.velocity = new Vector2(-1 * slowSpeed, 0);
        }
    }
}
