using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TpAdder : MonoBehaviour
{
    GameObject player;
    GameObject tpGlow;
    Animator glowAnim;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
        tpGlow = GameObject.FindGameObjectWithTag("TpGlow");
        glowAnim = tpGlow.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            MainSceneController.tpAmount++;
            glowAnim.SetTrigger("Glow");
            Destroy(gameObject);
        }
    }
}
