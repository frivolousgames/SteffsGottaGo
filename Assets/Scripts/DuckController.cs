using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : ObstacleController
{
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

        //Groan
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    private void Update()
    {
        DestroyAtEnd();

        //Groan
        groanWave = GameObject.FindGameObjectWithTag("GroanWave");
    }

    private void FixedUpdate()
    {
        if(hit == false)
        {
            rb.velocity = -Vector2.right * speed;
        }
    }

    
}
