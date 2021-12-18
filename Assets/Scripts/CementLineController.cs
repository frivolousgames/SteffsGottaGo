using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CementLineController : MonoBehaviour
{
    public float speed;

    public Transform restartPos;

    Vector2 startPos;
    Vector2 endPos;

    Quaternion startRot;

    Quaternion restartRot;
    Quaternion endRot;

    private void Awake()
    {
        startPos = transform.localPosition;
        endPos = new Vector2(-restartPos.localPosition.x, restartPos.localPosition.y);

        startRot = transform.localRotation;
        restartRot = new Quaternion(0,0,35,1);
        endRot = new Quaternion(restartRot.x, restartRot.y, -restartRot.z, 1);
    }

    private void Update()
    {
        if(transform.localPosition.x < endPos.x)
        {
            transform.localPosition = restartPos.localPosition;
        }

        if(CameraMover.isMoving == true || SurvivalCameraMover.isMoving == true)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.Euler(0, 0, transform.localPosition.x * 3.5f);
        }
        //Debug.Log(transform.rotation.z);
    }

}
