using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAdder : MonoBehaviour
{
    GameObject player;

    public GameObject timeAddAnim;
    GameObject adderPrefab;
    Transform canvas;
    Transform adderSpawn;

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
            TimerController.maxTime += 2;
            adderPrefab = Instantiate(timeAddAnim, canvas.position, Quaternion.identity, canvas);
            adderPrefab.GetComponentInChildren<Text>().text = "+2 SECONDS";
            Instantiate(sound, null);
            MainSceneController.itemAmount++;
            Destroy(gameObject);
        }
    }
}
