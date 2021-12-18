using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(0f, 0f, speed);
    }
}
