using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LilyController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    GameObject lilyLine;

    public GameObject boomerang;
    public Transform boomSpawn;

    //bool entering;
    bool thrown;
    //bool leaving;

    public float speed;

    GameObject cam;

    public GameObject destroySmoke;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //entering = true;
        rb.velocity = -Vector2.right * speed;
    }
    private void Update()
    {
        DestroyAtEnd();
    }


    private void Start()
    {
        lilyLine = GameObject.FindGameObjectWithTag("LilyLine");
        cam = FindObjectOfType<Camera>().gameObject;
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == lilyLine)
        {
            rb.velocity = Vector2.zero;
            //entering = false;
            anim.SetTrigger("throw");
            anim.speed = 0;
            StartCoroutine("ThrowWait");
        }
    }

    IEnumerator ThrowWait()
    {
        yield return new WaitForSeconds(.25f);
        anim.speed = 1;
        yield return new WaitForSeconds(1f);
        transform.localScale = new Vector2(-1f, 1f);
        anim.SetTrigger("leave");
        //leaving = true;
        rb.velocity = Vector2.right * speed;
    }

    public void SpawnBoomerang()
    {
        Instantiate(boomerang, boomSpawn.position, boomerang.transform.rotation, cam.transform);
    }

    void DestroyAtEnd()
    {
        if (SceneManager.GetActiveScene().name != "Survival")
        {
            if (TimerController.counting == false || MainSceneController.won == true || MainSceneController.popActive == true)
            {
                Instantiate(destroySmoke, transform.position, Quaternion.identity, transform.parent);
                Destroy(gameObject);
            }
        }
        else
        {
            if (SurvivalTimer.counting == false)
            {
                Instantiate(destroySmoke, transform.position, Quaternion.identity, transform.parent);
                Destroy(gameObject);
            }
        }
    }
}
