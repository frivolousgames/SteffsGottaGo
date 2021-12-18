using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAdder : MonoBehaviour
{
    GameObject player;

    public GameObject coinAddAnim;
    GameObject adderPrefab;
    Transform canvas;
    Transform adderSpawn;

    public int amount;

    public GameObject sound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerHitCollider");
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").transform;
        adderSpawn = GameObject.FindGameObjectWithTag("AdderSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            int i = PlayerPrefs.GetInt("Coins", 0);
            PlayerPrefs.SetInt("Coins", i + amount);
            adderPrefab = Instantiate(coinAddAnim, canvas.position, Quaternion.identity, canvas);
            adderPrefab.GetComponentInChildren<Text>().text = "+" + amount + " STEFF COINS";
            Instantiate(sound, null);
            Destroy(gameObject);
        }
    }
}
