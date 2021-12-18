using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayer : MonoBehaviour
{
    Collider2D physCol;
    Collider2D col;

    private void Awake()
    {
        col = GetComponent <Collider2D>();
    }

    private void Start()
    {
        physCol = GameObject.FindGameObjectWithTag("PhysicalCollider").GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        Physics2D.IgnoreCollision(col, physCol);
    }
}
