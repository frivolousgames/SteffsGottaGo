using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : ObstacleController
{
    public float rotSpeed;

    GameObject ground;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        transform.Rotate(0f, 0f, rotSpeed);

        DestroyAtEnd();

        //Groan
        groanWave = GameObject.FindGameObjectWithTag("GroanWave");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            PlayerController.hit = true;
            SurivialPlayerController.hit = true;
            hit = true;
            col.enabled = false;
            Destroy(gameObject);
        }

        //Groan
        if (other.gameObject == groanWave)
        {
            Instantiate(screenSpatter, new Vector2(Random.Range(mainCamera.gameObject.transform.position.x - 1.2f, mainCamera.gameObject.transform.position.x + 1.2f), Random.Range(-.2f, .2f)), new Quaternion(0f, 0f, Random.Range(0, 360), 1), mainCanvas.transform);
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity, mainCamera.transform);
            Destroy(gameObject);
        }
    }
}
