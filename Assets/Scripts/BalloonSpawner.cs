using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloon;
    public float waitTime;

    private void Awake()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(2f);
        while(MainSceneController.shartNumber < 6)
        {
            if(CameraMover.isMoving == true)
            {
                Instantiate(balloon, transform.position, Quaternion.identity, transform);
                Debug.Log("Balloon");
                yield return new WaitForSeconds(waitTime);
            }
            yield return null;
        }
    }
}
