using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperRonController : ObstacleController
{
    GameObject fartLine;
    bool walking;

    AnimatorStateInfo animInfo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
        playerController = player.GetComponent<PlayerController>();
        playerAnim = player.GetComponentInChildren<Animator>();
        fartLine = GameObject.FindGameObjectWithTag("SwitchCollider");

        //Groan
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    private void Update()
    {
        Walking();
        DestroyAtEnd();
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
        //Debug.Log("Walking: " + walking);

        //Groan
        groanWave = GameObject.FindGameObjectWithTag("GroanWave");
    }

    private void FixedUpdate()
    {
        Attacking();
        Fart();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject == fartLine)
        {
            anim.SetTrigger("Fart");
        }
    }

    void Attacking()
    {
        if (walking == true)
        {
            rb.velocity = Vector2.left * speed;
        }
    }

    void Fart()
    {
        if (walking == false)
        {
            rb.velocity = Vector2.zero;
        }
    }
    void Walking()
    {
        if (animInfo.tagHash == Animator.StringToHash("Walk"))
        {
            walking = true;
        }
        else
        {
            walking = false;
        }
    }
}
