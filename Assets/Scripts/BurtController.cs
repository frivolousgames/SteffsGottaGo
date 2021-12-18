using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurtController : ObstacleController
{
    public AudioSource soundPlayer;
    public AudioClip[] sounds;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        col = GetComponent<BoxCollider2D>();
        soundPlayer.clip = sounds[Random.Range(0, sounds.Length)];
        soundPlayer.Play();
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
        //Groan
        groanWave = GameObject.FindGameObjectWithTag("GroanWave");
        DestroyAtEnd();
    }

    private void FixedUpdate()
    {
        if (hit == false)
        {
            rb.velocity = -Vector2.right * speed;
        }
    }
}
