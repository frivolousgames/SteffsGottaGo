using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonController : ObstacleController
{
    GameObject crouchLine;
    bool attacking;

    public float dropSpeed;

    public AudioSource soundPlayer;
    public AudioClip one;
    public AudioClip two;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
        playerController = player.GetComponent<PlayerController>();
        playerAnim = player.GetComponentInChildren<Animator>();
        crouchLine = GameObject.FindGameObjectWithTag("CrouchLine");

        //Groan
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    private void Update()
    {
        anim.SetBool("Attacking", attacking);    
        DestroyAtEnd();

        //Groan
        groanWave = GameObject.FindGameObjectWithTag("GroanWave");
    }

    private void FixedUpdate()
    {
        Attacking();
        Swoop();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if(other.gameObject == crouchLine)
        {
            attacking = true;
            soundPlayer.clip = two;
            soundPlayer.Play();
        }
    }

    void Attacking()
    {
        if(attacking == true)
        {
            rb.velocity = Vector2.left * speed;
        }
    }

    void Swoop()
    {
        if(attacking == false)
        {
            rb.velocity = Vector2.down * dropSpeed; ;
        }
    }
}
