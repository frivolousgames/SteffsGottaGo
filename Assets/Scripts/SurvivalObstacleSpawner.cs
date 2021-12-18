using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    GameObject obstacle;

    public Transform[] spawnPoints;
    Transform spawnPoint;

    int oIndex;
    GameObject previousOb;

    float waitTime;
    GameObject[] prefabs;
    GameObject prefab;

    private void Awake()
    {
        StartCoroutine("Spawn");
    }

    private void Update()
    {
        prefabs = GameObject.FindGameObjectsWithTag("Obstacle");
        //Debug.Log(SurvivalTimer.counting);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(.5f);
        while (SurvivalTimer.counting != false)
        {
            SetObstacle();
            SetWaitTime(obstacle.name);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SetObstacle()
    {
        if (SurvivalCameraMover.isMoving == true && SurivialPlayerController.isHit != true)
        {
            int[] selObs = SurvivalSceneController.levelObstacles;
            int ob = Random.Range(0, selObs.Length);
            oIndex = selObs[ob];
            if (obstacle != obstacles[oIndex])
            {
                obstacle = obstacles[oIndex];
                spawnPoint = spawnPoints[oIndex];
                if (obstacle != null)
                {
                    prefab = Instantiate(obstacle, spawnPoint.position, Quaternion.identity, transform);
                }
            }
            else
            {
                //Debug.Log(obstacle.name);
                SetObstacle();
            }
        }
        else if (prefabs.Length > 1)
        {
            Destroy(prefab);
        }
    }

    void SetWaitTime(string obstacleName)
    {
        switch (obstacleName)
        {
            case "Duck":
                waitTime = 1.9f;
                break;
            case "Lawnmower":
                waitTime = 2.1f;
                break;
            case "Pigeon":
                waitTime = 2.1f;
                break;
            case "PaperPlane":
                waitTime = 2.5f;
                break;
            case "SidewalkCrack":
                waitTime = 2.1f;
                break;
            case "BurtSampson":
                waitTime = 2.1f;
                break;
            case "Spider":
                waitTime = 2.1f;
                break;
            case "Girder":
                waitTime = 2f;
                break;
            case "SuperRon":
                waitTime = 2.5f;
                break;
            case "GolfCart":
                waitTime = 2.3f;
                break;
            case "Delilah":
                waitTime = 2.4f;
                break;
            case "Lily":
                waitTime = 2.4f;
                break;
            case "Drone":
                waitTime = 2.3f;
                break;
            case "UFO":
                waitTime = 6.3f;
                break;
            case "Frog":
                waitTime = 2.6f;
                break;
            case null:
                waitTime = 0f;
                break;
            default:
                waitTime = 2.1f;
                break;
        }
    }
}
