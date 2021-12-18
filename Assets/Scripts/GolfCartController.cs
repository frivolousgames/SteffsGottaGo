using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfCartController : ObstacleController
{
    public GameObject[] groundColliders;
    public AudioSource honk;
    public AudioSource motor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        col = GetComponent<PolygonCollider2D>();
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

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            PlayerController.hit = true;
            SurivialPlayerController.hit = true;

            hit = true;
            col.enabled = false;
            foreach(GameObject g in groundColliders)
            {
                Destroy(g);
            }
            honk.Play();
            StartCoroutine("MotorPitch");
            //anim.SetTrigger("hit");
        }
        //Groan
        if (other.gameObject == groanWave)
        {
            Instantiate(screenSpatter, new Vector2(Random.Range(mainCamera.gameObject.transform.position.x - 1.2f, mainCamera.gameObject.transform.position.x + 1.2f), Random.Range(-.2f, .2f)), new Quaternion(0f, 0f, Random.Range(0, 360), 1), mainCanvas.transform);
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity, mainCamera.transform);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        DestroyAtEnd();

        //Groan
        groanWave = GameObject.FindGameObjectWithTag("GroanWave");
    }

    private void FixedUpdate()
    {
        if (hit == false)
        {
            rb.velocity = -Vector2.right * speed;
        }
        else
        {
            rb.velocity = -Vector2.right * speed * 2;
        }

    }

    IEnumerator MotorPitch()
    {
        while(motor.pitch < 2)
        {
            motor.pitch += .01f;
            motor.volume -= .025f;
            yield return new WaitForSeconds(.05f);
        }
    }

    void IsHIt()
    {
        if(PlayerController.isHit == true || PlayerController.hitGround == true || SurivialPlayerController.isHit == true || SurivialPlayerController.hitGround == true)
        {
            foreach (GameObject g in groundColliders)
            {
                g.SetActive(false);
            }
        }
        else
        {
            foreach(GameObject g in groundColliders)
            {
                if(g.activeInHierarchy == false)
                {
                    g.SetActive(true);
                }
            }
        }
    }
}
