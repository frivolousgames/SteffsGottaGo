using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
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

    int level;
    float waitMod;

    public static float peanutTime;

    //public static GameObject pap;

    private void Awake()
    {
        StartCoroutine("Spawn");
        peanutTime = 0f;
    }

    private void Start()
    {
        level = PlayerPrefs.GetInt("Level", 0);
        if (PlayerPrefs.HasKey("Peanut " + level))
        {
            peanutTime = .5f;
            Debug.Log("Wait");
        }
        SetWaitCurve();
    }

    private void Update()
    {
        prefabs = GameObject.FindGameObjectsWithTag("Obstacle");
        //Debug.Log(MainSceneController.selectedObstacles[MainSceneController.selectedObstacles.Length - 1]);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(.5f);
        while (MainSceneController.won != true || TimerController.counting != false)
        {
            SetObstacle();
            SetWaitTime(obstacle.name);
            waitTime -= waitMod;
            waitTime += peanutTime;
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SetObstacle()
    {
        if (CameraMover.isMoving == true && MainSceneController.won == false && PlayerController.isHit != true && MainSceneController.popActive != true)
        {
            //Debug.Log("Pre: " + obstacle);
            int[] selObs = MainSceneController.selectedObstacles;
            int ob = Random.Range(0, selObs.Length);
            oIndex = selObs[ob];
            //oIndex = Random.Range(selObs[0], selObs[selObs.Length - 1] + 1);
            
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
        else if(prefabs.Length > 1)
        {
            Destroy(prefab);
        }
    }

    void SetWaitTime(string obstacleName)
    {
        switch (obstacleName)
        {
            case "Duck":
                waitTime = 2.2f;
                break;
            case "Lawnmower":
                waitTime = 2.4f;
                break;
            case "Pigeon":
                waitTime = 2.4f;
                break;
            case "PaperPlane":
                waitTime = 2.8f;
                break;
            case "SidewalkCrack":
                waitTime = 2.4f;
                break;
            case "BurtSampson":
                waitTime = 2.4f;
                break;
            case "Spider":
                waitTime = 2.4f;
                break;
            case "Girder":
                waitTime = 2.3f;
                break;
            case "SuperRon":
                waitTime = 3.1f;
                break;
            case "GolfCart":
                waitTime = 2.6f;
                break;
            case "Delilah":
                waitTime = 2.7f;
                break;
            case "Lily":
                waitTime = 2.7f;
                break;
            case "Drone":
                waitTime = 2.6f;
                break;
            case "UFO":
                waitTime = UfoController.timeMulti;
                break;
            case "Frog":
                waitTime = 2.9f;
                break;
            case null:
                waitTime = 0f;
                break;
            default:
                waitTime = 2.4f;
                break;
        }
    }

    void SetWaitCurve()
    {
        if(level >= 5 && level <= 9)
        {
            waitMod = .1f;
        }
        else if (level >= 10 && level <= 14)
        {
            waitMod = .15f;
        }
        else if (level >= 15 && level <= 19)
        {
            waitMod = .2f;
        }
        else if (level >= 20 && level <= 25)
        {
            waitMod = .25f;
        }
        else
        {
            waitMod = 0;
        }
    }
}
