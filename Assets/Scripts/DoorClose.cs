using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorClose : MonoBehaviour
{
    GameObject player;

    Animator anim;
    Rigidbody2D rb;

    public GameObject popStopper;

    public static bool inPotty;

    bool moving;
    public float moveSpeed;
    public static bool stopped;

    public UnityEvent doorClose;

    private void OnEnable()
    {
        moving = true;
        stopped = false;
    }

    private void OnDisable()
    {
        inPotty = false;
        stopped = false;
    }

    private void Awake()
    {
        inPotty = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
    }

    private void FixedUpdate()
    {
        Moving();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            anim.SetTrigger("Close");
            inPotty = true;
            doorClose.Invoke();
        }

        if(other.gameObject == popStopper)
        {
            moving = false;
            stopped = true;
        }
    }

    void Moving()
    {
        if(moving == true)
        {
            rb.velocity = Vector2.left * moveSpeed * Time.deltaTime;
        }

        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
