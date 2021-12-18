using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player;

    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.AddForce(player.transform.position * Time.deltaTime * speed);
    }
}
