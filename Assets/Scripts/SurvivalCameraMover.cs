using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalCameraMover : MonoBehaviour
{
    public float speed;

    public static bool isMoving;

    private void Awake()
    {
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving == true)
        {
            if (SurvivalTimer.counting == true)
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
