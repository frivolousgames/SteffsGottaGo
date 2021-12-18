using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonController : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;

    public GameObject explosion;

    GameObject[] bullets;

    float min;
    float max;

    string shartLetter;

    public GameObject letter;
    GameObject letterPrefab;
    Text letterText;

    Camera cam;
    GameObject canvas;

    public GameObject spatter;

    GameObject balloonCancel;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        min = transform.position.y - 1.25f;
        max = transform.position.y + 1.25f;   
    }

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        SetLetter(MainSceneController.shartNumber);
        MainSceneController.shartNumber++;
        balloonCancel = GameObject.FindGameObjectWithTag("BalloonCancel");
    }

    private void Update()
    {
        bullets = GameObject.FindGameObjectsWithTag("NutBullet");
        PingPong();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(bullets != null)
        {
            foreach (GameObject b in bullets)
            {
                if (other.gameObject == b)
                {
                    Instantiate(explosion, transform.position, Quaternion.identity, null);
                    Instantiate(spatter, new Vector2(Random.Range(cam.gameObject.transform.position.x - 1.2f, cam.gameObject.transform.position.x + 1.2f), Random.Range(-.2f, .2f)), new Quaternion(0f, 0f, Random.Range(0, 360), 1), canvas.transform);
                    letterPrefab = Instantiate(letter, transform.position, Quaternion.identity, canvas.transform);
                    letterPrefab.GetComponent<Text>().text = shartLetter;
                    MainSceneController.shartCollected++;
                    MainSceneController.itemAmount++;
                    Destroy(b);
                    Destroy(gameObject);
                }
            }
        }
        if(other.gameObject == balloonCancel)
        {
            MainSceneController.shartCancel = true;
        }
    }

    void PingPong()
    {
        transform.position = new Vector2(transform.position.x, Mathf.SmoothStep(min, max, Mathf.PingPong(Time.time * .5f, 1)));
    }

    void SetLetter(int letter)
    {
        switch (letter)
        {
            case 1:
                shartLetter = "S";
                break;
            case 2:
                shartLetter = "H";
                break;
            case 3:
                shartLetter = "A";
                break;
            case 4:
                shartLetter = "R";
                break;
            case 5:
                shartLetter = "T";
                break;
            case 0:
                shartLetter = "Uh Oh";
                break;
            default:
                shartLetter = "D";
                break;
        }
    }
}
