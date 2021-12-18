using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMover : MonoBehaviour
{

    public float moveSpeed;

    bool moveTime;

    Vector3 originalPos;

    Camera cam;
    SpriteRenderer sr;

    float edge;
    float newStart;

    private void Start()
    {
        originalPos = new Vector3(0f, transform.position.y);
        cam = FindObjectOfType<Camera>();
        sr = GetComponent<SpriteRenderer>();
        moveTime = true;
        Debug.Log("xMin: " + sr.bounds.min.x * 2);
        Debug.Log("xMax: " + sr.bounds.max.x * 2);
        edge = sr.bounds.min.x * 2;
        newStart = sr.bounds.max.x * 2;
    }

    private void Update()
    {
        MoveBg();
        //Debug.Log("posX: " + transform.localPosition.x);

    }

    void MoveBg()
    {
        if (moveTime)
        {
            transform.Translate(-Vector2.right * Time.deltaTime * moveSpeed);
            if(transform.localPosition.x < edge)
            {
                Debug.Log("END");
                transform.localPosition = new Vector3(newStart, transform.position.y);
                //originalPos = transform.position;
            }
        }
    }
}
