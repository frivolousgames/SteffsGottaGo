using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackController : ObstacleController
{
    private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
        playerController = player.GetComponent<PlayerController>();
        playerAnim = player.GetComponentInChildren<Animator>();

        //Groan
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        DestroyAtEnd();
        if (CameraMover.isMoving == true || SurvivalCameraMover.isMoving == true)
        {
            transform.Translate(-Vector2.right * Time.deltaTime * speed);
        }

        //Groan
        groanWave = GameObject.FindGameObjectWithTag("GroanWave");
    }
}
