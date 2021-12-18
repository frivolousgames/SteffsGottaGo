using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UfoController : ObstacleController
{
    public float startSpeed;

    public GameObject laserBeam;
    public Transform laserParent;
    public Transform laserSpawn;

    public GameObject flame;

    GameObject ufoLine;

    public bool stopped;

    public float leaveSpeed;

    public GameObject twinkle;
    public GameObject leaveSound;

    public static float timeMulti;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timeMulti = 5.3f;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
        playerController = player.GetComponent<PlayerController>();
        playerAnim = player.GetComponentInChildren<Animator>();
        rb.velocity = Vector2.left * startSpeed;
        ufoLine = GameObject.FindGameObjectWithTag("UfoLine");

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    private void Update()
    {
        anim.SetBool("stopped", stopped);
        if(SceneManager.GetActiveScene().name == "Survival")
        {
            anim.SetBool("isHit", SurivialPlayerController.isHit);

        }
        else
        {
            anim.SetBool("isHit", PlayerController.isHit);

        }

        DestroyAtEnd();
        if(PlayerController.isHit == true || SurivialPlayerController.isHit == true)
        {
            timeMulti = 0f;
        }
        Debug.Log("Multi: " + timeMulti);
    }

    public void Shoot()
    {
        GameObject laserFab = Instantiate(laserBeam, laserSpawn.position, laserParent.localRotation, null);
        laserFab.GetComponent<Rigidbody2D>().velocity = laserParent.right * leaveSpeed;
        flame.SetActive(true);
        StartCoroutine("ResetFlame");
    }

    IEnumerator ResetFlame()
    {
        yield return new WaitForSeconds(.2f);
        flame.SetActive(false);
    }

    public void Leave()
    {
        rb.velocity = Vector2.left * leaveSpeed;
        Instantiate(leaveSound, null);
    }

    public void DestroyUfo()
    {
        Instantiate(twinkle, transform.position, Quaternion.identity, mainCamera.transform);
        Destroy(gameObject);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == ufoLine && stopped == false)
        {
            rb.velocity = Vector2.zero;
            stopped = true;
        }
    }
}
