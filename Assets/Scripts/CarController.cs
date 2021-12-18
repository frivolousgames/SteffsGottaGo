using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    public Sprite[] cars;

    public SpriteRenderer sr;

    public AudioSource vroom;

    private void Awake()
    {
        vroom.pitch = Random.Range(.9f, 1.1f);
        rb = GetComponent<Rigidbody2D>();
        sr.sprite = cars[Random.Range(0, cars.Length)];
    }

    private void Update()
    {
        rb.velocity = Vector2.right * transform.localScale.x * speed;
    }
}
