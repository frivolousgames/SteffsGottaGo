using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : ObstacleController
{
    bool isGrounded;
    bool landed;

    public Collider2D groundCol;
    public LayerMask groundLayer;

    public float jumpForce;
    public float jumpWait;

    public float attackSpeed;
    public float attackHeight;

    public float rotSpeed;

    bool ready;

    GameObject frogCollider;

    Vector2 rbVelocity;

    GameObject ground;

    BoxCollider2D playerPhys;

    AudioSource soundPlayer;
    public AudioClip[] sounds;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        soundPlayer = GetComponent<AudioSource>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
        playerController = player.GetComponent<PlayerController>();
        playerAnim = player.GetComponentInChildren<Animator>();
        playerPhys = GameObject.FindGameObjectWithTag("PhysicalCollider").GetComponent<BoxCollider2D>();

        //Groan
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");

        StartCoroutine("Forward");

        frogCollider = GameObject.FindGameObjectWithTag("FrogCollider");

        ground = GameObject.FindGameObjectWithTag("Ground");
    }

    private void Update()
    {
        DestroyAtEnd();

        //Groan
        groanWave = GameObject.FindGameObjectWithTag("GroanWave");
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("Landed", landed);
        //rb.velocity = rbVelocity;

        /*if(isGrounded == false)
        {
            transform.rotation = Quaternion.Lerp(Quaternion.identity, new Quaternion(0, 0, 20, 1), Time.deltaTime * rotSpeed);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }*/
    }



    private void FixedUpdate()
    {
        isGrounded = Physics2D.IsTouchingLayers(groundCol, groundLayer);
        Physics2D.IgnoreCollision(groundCol, playerPhys);
    }

    private void OnDestroy()
    {
        frogCollider.SetActive(true);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if(other.gameObject == frogCollider)
        {
            ready = true;
            frogCollider.SetActive(false);
            StartCoroutine("Attack");
        }
    }

    IEnumerator Forward()
    {
        soundPlayer.clip = sounds[0];
        while (ready == false)
        {

            if (isGrounded == true)
            {
                if(landed == false)
                {
                    rb.velocity = Vector3.zero;
                    yield return new WaitForSeconds(jumpWait);
                    landed = true;
                }
                else
                {
                    rb.AddForce(new Vector2(speed, jumpForce), ForceMode2D.Impulse);
                    anim.SetTrigger("Jump");
                    soundPlayer.Play();
                    yield return new WaitForSeconds(.05f);
                    landed = false;

                }
                yield return null;
            }
            
            else
            {
                yield return null;
            }
            
        }
    }

    IEnumerator Attack()
    {
        while(ready == true)
        {
            if (isGrounded == true)
            {
                if (landed == false)
                {
                    rb.velocity = Vector3.zero;
                    yield return new WaitForSeconds(Random.Range(.3f, .8f));
                    landed = true;
                    soundPlayer.clip = sounds[1];
                }
                else
                {
                    rb.AddForce(new Vector2(attackSpeed, attackHeight), ForceMode2D.Impulse);
                    soundPlayer.Play();
                    anim.SetTrigger("Jump");
                    yield return new WaitForSeconds(.02f);
                    landed = false;
                    ready = false;
                    yield return new WaitForSeconds(1f);
                    frogCollider.SetActive(true);
                }
                yield return null;
            }

            else
            {
                yield return null;
            }
        }
        
        
    }



}
