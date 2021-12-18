using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutBullet : MonoBehaviour
{
    Rigidbody2D rb;

    public float upSpeed;
    public float rightSpeed;

    private void Awake()
    {
        Vector2 speed = new Vector2(rightSpeed, upSpeed);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(speed, ForceMode2D.Impulse);
    }
}
