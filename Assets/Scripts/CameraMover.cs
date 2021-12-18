using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    //118 in 60 secs

    public float speed;

    public static bool isMoving;

    public static int distance;

    private void Awake()
    {
        isMoving = true;
    }

    private void Update()
    {
        distance = (int)transform.localPosition.x;
        //Debug.Log(distance);
        if(isMoving == true)
        {
            if (TimerController.counting == true)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                isMoving = false;
            }
        }
    }

    

}
