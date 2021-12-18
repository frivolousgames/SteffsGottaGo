using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            Destroy(gameObject);
        }
    }
}
