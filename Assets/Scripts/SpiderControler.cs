using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderControler : ObstacleController
{
    GameObject crouchLine;
    bool attacking;

    public float dropSpeed;

    public AudioSource soundPlayer;
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
        //anim.SetBool("Attacking", attacking);
        Attacking();
        Swoop();
        DestroyAtEnd();
        if(CameraMover.isMoving == true || SurvivalCameraMover.isMoving == true)
        {
            transform.Translate(-Vector2.right * Time.deltaTime * speed);
        }

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
            col.enabled = false;
            anim.SetTrigger("hit");
        }
        if (other.gameObject == crouchLine)
        {
            attacking = true;
            anim.SetTrigger("attack");
            soundPlayer.clip = two;
            soundPlayer.Play();
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
            rb.velocity = Vector2.zero;
        }
    }

    void Swoop()
    {
        if (attacking == false)
        {
            rb.velocity = Vector2.down * dropSpeed;
        }
    }

    public void DestroyPostFade()
    {
        Destroy(gameObject);
    }
}
