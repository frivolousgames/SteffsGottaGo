using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangController : ObstacleController
{
    public float rotSpeed;
    public float turnSpeed;
    float angle = 0f;

    Vector2 turnTarget;

    GameObject ground;
    GameObject boomerangFlipper;

    bool turning;
    bool turned;

    public AudioSource sound;
    bool playing;

    public GameObject gotcha;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        rb.velocity = Vector2.left * speed;
        StartCoroutine("SoundShifter");
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
        if(player.GetComponent<PlayerController>() != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
        else
        {
            playerController = player.GetComponent<SurivialPlayerController>();
        }
        playerAnim = player.GetComponentInChildren<Animator>();

        ground = GameObject.FindGameObjectWithTag("Ground");
        boomerangFlipper = GameObject.FindGameObjectWithTag("BoomerangFlipper");

        //Groan
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");

    }

    private void Update()
    {
        transform.Rotate(0f, 0f, rotSpeed);
        if(turning == true)
        {
            TurnAround();
            rb.velocity = Vector2.zero;
        }
        if(turned == true)
        {
            Turned();
        }
        DestroyAtEnd();
        //Debug.Log("Turning: " + turning);

        //Groan
        groanWave = GameObject.FindGameObjectWithTag("GroanWave");
    }

    private void OnBecameInvisible()
    {
        sound.Stop();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            PlayerController.hit = true;
            SurivialPlayerController.hit = true;
            hit = true;
            col.enabled = false;
            StartCoroutine(GotchaWait());
            if(turning == false && turned == false)
            {
                StartCoroutine("StopSound");
            }
            //anim.SetTrigger("hit");
        }
        
        if (other.gameObject == boomerangFlipper)
        {
            turning = true;
            turnTarget = new Vector2(transform.position.x, ground.transform.position.y);
        }

        if(other.gameObject == ground)
        {
            turning = false;
            turned = true;
        }

        //Groan
        if (other.gameObject == groanWave)
        {
            Instantiate(screenSpatter, new Vector2(Random.Range(mainCamera.gameObject.transform.position.x - 1.2f, mainCamera.gameObject.transform.position.x + 1.2f), Random.Range(-.2f, .2f)), new Quaternion(0f, 0f, Random.Range(0, 360), 1), mainCanvas.transform);
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity, mainCamera.transform);
            Destroy(gameObject);
        }
    }

    IEnumerator GotchaWait()
    {
        yield return new WaitForSeconds(.3f);
        Instantiate(gotcha, null);
    }

    IEnumerator StopSound()
    {
        yield return new WaitForSeconds(.5f);
        sound.Stop();
    }

    void TurnAround()
    {
        angle += .01f * Time.deltaTime * turnSpeed;
        Mathf.Clamp(angle, 0, 1);
        transform.position = Vector3.Slerp(transform.position, turnTarget, angle);
    }

    void Turned()
    {
        rb.velocity = -Vector2.left * speed;
    }

    IEnumerator SoundShifter()
    {
        while(playing == true)
        {
            while (sound.isPlaying)
            {
                yield return null;
            }
            sound.pitch = Random.Range(.9f, 1f);
        }
    }
}
