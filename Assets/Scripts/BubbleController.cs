using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    GameObject grabber;

    private void Start()
    {
        grabber = GameObject.FindGameObjectWithTag("Grabber");
    }

    private void Update()
    {
        Debug.Log("HIT :" + GrabberController.empty);
    }

    /*private void OnDestroy()
    {
        if(GrabberController.working == false)
        {
            GrabberController.empty = true;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == grabber)
        {
            GrabberController.empty = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == grabber)
        {
            if(GrabberController.working == false)
            {
                GrabberController.empty = true;
            }
        }
    }
}
