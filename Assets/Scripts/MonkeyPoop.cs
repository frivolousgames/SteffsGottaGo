using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyPoop : MonoBehaviour
{
    Rigidbody2D rb;

    public float power;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * power, ForceMode2D.Impulse);
    }

    private void Start()
    {
        
    }
}
