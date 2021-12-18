using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddGas : MonoBehaviour
{
    GameObject player;

    Slider gasMeter;

    public GameObject sound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
        gasMeter = GameObject.FindGameObjectWithTag("GasMeter").GetComponent<Slider>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            gasMeter.value += 1f;
            Instantiate(sound, null);
            MainSceneController.itemAmount++;
            Destroy(gameObject);
        }
    }
}
