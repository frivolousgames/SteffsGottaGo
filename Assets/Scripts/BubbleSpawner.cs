using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public Transform grabber;
    public Transform leftBorder;
    public Transform rightBorder;

    public GameObject bubble;

    GameObject bubblePrefab;

    Vector2 bubblePos;

    float offsetL;
    float offsetR;

    Vector2 posL;
    Vector2 posR;

    public float yPos;

    List<Vector2> posArray;

    bool spawning;
    public static bool spawnOn;

    private void Awake()
    {
        posArray = new List<Vector2>();
        spawning = true;
        spawnOn = true;
        StartCoroutine("SpawnBubbles");
    }

    private void Update()
    {
        offsetR = grabber.position.x + 4f;
        offsetL = grabber.position.x - 4f;

        posL = new Vector2(Random.Range(leftBorder.position.x, offsetL), yPos);
        posR = new Vector2(Random.Range(rightBorder.position.x, offsetR), yPos);

        posArray.Add(posL);
        posArray.Add(posR);

        if (posL.x < leftBorder.position.x)
        {
            bubblePos = posR;
        }
        else if(posR.x < rightBorder.position.x)
        {
            bubblePos = posL;
        }
        else
        {
            bubblePos = posArray[Random.Range(0, 2)];
        }

        spawnOn = !GrabberController.working;
    }

    IEnumerator SpawnBubbles()
    {
        while(spawning == true)
        {
            if(spawnOn == true)
            {
                yield return new WaitForSeconds(Random.Range(.8f, 1.5f));
                bubblePrefab = Instantiate(bubble, bubblePos, Quaternion.identity, null);
            }
            yield return null;
        }
    }
}
