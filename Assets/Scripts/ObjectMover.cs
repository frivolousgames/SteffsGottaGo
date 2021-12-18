using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        if (CameraMover.isMoving == true)
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
    }
}
