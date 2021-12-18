using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SurivialPlayerController : MonoBehaviour
{
    public BoxCollider2D hitcollider;
    public Collider2D groundCol;
    Rigidbody2D rb;

    public LayerMask groundLayer;
    public static bool isGrounded;

    public float jumpForce;

    public Animator anim;

    bool isDucking;
    bool isRunning;
    public static bool isHit;

    GameObject[] obstacles;

    public float hitForce;

    EdgeCollider2D hitGroundCol;
    GameObject ground;
    public static bool hit;
    public static bool hitGround;

    public GameObject dazedRing;

    public GameObject smoke;
    ParticleSystem.MainModule ps;

    //Shooting
    public GameObject nutBullet;
    public Transform nutBulletSpawn;
    bool isShooting;
    public float shotWaitTime;
    public GameObject oFace;

    //Events
    public UnityEvent hitEvent;
    public UnityEvent duckEvent;
    public UnityEvent jumpEvent;
    public UnityEvent hitGroundEvent;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hitGroundCol = GetComponent<EdgeCollider2D>();
        hitGround = false;
        hit = false;
        isHit = false;
    }

    private void Start()
    {
        ps = smoke.GetComponent<ParticleSystem>().main;
        ground = GameObject.FindGameObjectWithTag("Ground");
    }
    private void Update()
    {
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isDucking", isDucking);
        anim.SetBool("isHit", isHit);

        Running();
        Hit();

        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        //Debug.Log("isGrounded " + isGrounded);
    }

    private void FixedUpdate()
    {
        if (isHit == false)
        {
            isGrounded = Physics2D.IsTouchingLayers(groundCol, groundLayer);
        }
        else
        {
            isGrounded = false;
        }
        BeanBoost();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHit == true)
        {
            if (other.gameObject == ground)
            {
                HitGround();
            }
        }
    }

    public void Jump()
    {
        if (isGrounded == true && isHit == false && isDucking == false && SurvivalCameraMover.isMoving == true)
        {
            anim.ResetTrigger("Duck");
            anim.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            AudioController.psIndex = 2;
            jumpEvent.Invoke();
        }
    }

    public void Duck()
    {
        if (isGrounded == true && isHit == false && SurvivalCameraMover.isMoving == true)
        {
            if (isDucking == false)
            {
                anim.ResetTrigger("Jump");
                isDucking = true;
                anim.SetTrigger("Duck");
                StartCoroutine("UnDuck");
                AudioController.psIndex = 1;
                duckEvent.Invoke();
            }
        }
    }

    IEnumerator UnDuck()
    {
        yield return new WaitForSeconds(.6f);
        isDucking = false;
    }

    void Running()
    {
            if (isGrounded == true && isDucking == false && isHit == false)
            {
                if (SurvivalCameraMover.isMoving == true)
                {
                    isRunning = true;
                }
                else
                {
                    isRunning = false;
                }
            }
            else
            {
                isRunning = false;
            }
    }

    void Hit()
    {
        if (hit == true)
        {
            hit = false;
            anim.SetTrigger("Hit");
            anim.ResetTrigger("Jump");
            anim.ResetTrigger("Duck");
            isHit = true;
            hitcollider.enabled = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * hitForce, ForceMode2D.Impulse);
            AudioController.psIndex = 0;
            hitEvent.Invoke();
            //hitsound.Play();
            StartCoroutine("ColWait");
        }
    }

    IEnumerator ColWait()
    {
        yield return new WaitForSeconds(.4f);
        hitGroundCol.enabled = true;
        Debug.Log("Enabled");
    }

    void HitGround()
    {
        if (hitGround == false)
        {
            SurvivalCameraMover.isMoving = false;
            hitGroundCol.enabled = false;
            anim.SetTrigger("HitGround");
            Debug.Log("Hit Ground");
            hitGround = true;
            AudioController.psIndex = 3;
            hitGroundEvent.Invoke();
            //StartCoroutine("ResetPlayer");
        }
    }

    IEnumerator ResetPlayer()
    {
        yield return new WaitForSeconds(1.6f);
        isHit = false;
        hitGround = false;
        hitcollider.enabled = true;
        SurvivalCameraMover.isMoving = true;
        dazedRing.SetActive(false);
        //Debug.Log("RESET");
    }

    public void Lost()
    {
        anim.SetTrigger("Lost");
    }

    void BeanBoost()
    {
        if (GasMeter.gasUsed == true && rb.velocity.y < 1000 && isHit == false && SurvivalCameraMover.isMoving == true)
        {
            smoke.SetActive(true);
            ps.loop = true;
            rb.AddForce(Vector2.up * 210);
        }
        else
        {
            ps.loop = false;
        }
        if (isGrounded == true || hitGround == true)
        {
            smoke.SetActive(false);
        }
    }

    //Shooting

    public void ShootNuts()
    {
            if (isShooting == false)
            {
                Instantiate(nutBullet, nutBulletSpawn.position, Quaternion.identity, transform.parent);
                isShooting = true;
                oFace.SetActive(true);
                StartCoroutine("OFace");
                StartCoroutine("ShotWait");
            }
    }

    IEnumerator OFace()
    {
        yield return new WaitForSeconds(.3f);
        oFace.SetActive(false);

    }

    IEnumerator ShotWait()
    {
        yield return new WaitForSeconds(shotWaitTime);
        isShooting = false;
    }
}
