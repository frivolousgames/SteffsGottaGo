using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyHit : MonoBehaviour
{
    public GameObject explosion;
    public GameObject splat;
    public GameObject screenSpatter;

    GameObject mainCamera;
    GameObject mainCanvas;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("MonkeyPoop"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity, null);
            Instantiate(screenSpatter, new Vector2(Random.Range(mainCamera.gameObject.transform.position.x - 1.2f, mainCamera.gameObject.transform.position.x + 1.2f), Random.Range(-.2f, .2f)), new Quaternion(0f, 0f, Random.Range(0, 360), 1), mainCanvas.transform);
            Instantiate(splat, null);
            Destroy(gameObject);
        }
    }
}
