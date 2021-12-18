using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddAmmo : MonoBehaviour
{
    GameObject player;
    GameObject nutGlow;
    Animator glowAnim;

    public int ammoAdder;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
        nutGlow = GameObject.FindGameObjectWithTag("PeanutGlow");
        glowAnim = nutGlow.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            MainSceneController.ammoAmount += ammoAdder;
            glowAnim.SetTrigger("Glow");
            Destroy(gameObject);
        }
    }
}
