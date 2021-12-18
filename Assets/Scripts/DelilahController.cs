using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelilahController : ObstacleController
{
    GameObject flipLine;
    bool attacking;

    public AudioSource giggle;
    //public AudioClip one;
    //public AudioClip two;

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
        flipLine = GameObject.FindGameObjectWithTag("FlipLine");
        //Groan
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    private void Update()
    {
        //anim.SetBool("Attacking", attacking);
        Rebound();
        Left();
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
            col.enabled = false;
            Instantiate(giggle, null);
        }
        if (other.gameObject == flipLine)
        {
            attacking = true;
            //soundPlayer.clip = two;
            //soundPlayer.Play();
        }
        //Groan
        if (other.gameObject == groanWave)
        {
            Instantiate(screenSpatter, new Vector2(Random.Range(mainCamera.gameObject.transform.position.x - 1.2f, mainCamera.gameObject.transform.position.x + 1.2f), Random.Range(-.2f, .2f)), new Quaternion(0f, 0f, Random.Range(0, 360), 1), mainCanvas.transform);
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity, mainCamera.transform);
            Destroy(gameObject);
        }
    }

    void Rebound()
    {
        if (attacking == true)
        {
            rb.velocity = -Vector2.left * (speed + 5f);
            transform.localScale = new Vector2(-1f, 1f);
        }
        
    }

    void Left()
    {
        if (attacking == false)
        {
            rb.velocity = Vector2.left * speed; ;
        }
    }
}
