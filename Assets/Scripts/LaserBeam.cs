using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserBeam : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;

    GameObject ground;

    public GameObject ufoHole;
    Transform ufoHoleSpawn;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    private void Start()
    {
        ground = GameObject.FindGameObjectWithTag("Ground");
        ufoHoleSpawn = GameObject.FindGameObjectWithTag("UfoHoleSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == ground )
        {
            if(SceneManager.GetActiveScene().name == "Main")
            {
                if (CameraMover.isMoving == true && TimerController.counting == true)
                {
                    Instantiate(ufoHole, new Vector2(transform.position.x, ufoHoleSpawn.position.y), Quaternion.identity, GameObject.FindGameObjectWithTag("MainCamera").transform);
                    Destroy(gameObject);
                }
            }
            else
            {
                Instantiate(ufoHole, new Vector2(transform.position.x, ufoHoleSpawn.position.y), Quaternion.identity, GameObject.FindGameObjectWithTag("MainCamera").transform);
                Destroy(gameObject);
            }
        }
    }
}
