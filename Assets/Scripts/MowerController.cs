using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MowerController : ObstacleController
{
    GameObject ground;
    bool attacking;

    public float dropSpeed;

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
        ground = GameObject.FindGameObjectWithTag("Ground");

        //Groan
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    private void Update()
    {
        anim.SetBool("Attacking", attacking);
        Attacking();
        Swoop();
        DestroyAtEnd();

        //Groan
        groanWave = GameObject.FindGameObjectWithTag("GroanWave");
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject == ground)
        {
            attacking = true;
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
            rb.velocity = Vector2.down * dropSpeed; ;
        }
    }
}
