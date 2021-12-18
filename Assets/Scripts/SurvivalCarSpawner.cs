using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalCarSpawner : MonoBehaviour
{
    public GameObject car;
    GameObject carPrefab;

    public Transform[] spawnSpots;
    Transform spawnPos;
    int posNum;


    private void Awake()
    {
        StartCoroutine("SpawnCars");

        //Debug.Log("PN: " + posNum);
    }

    IEnumerator SpawnCars()
    {
        yield return new WaitForSeconds(.5f);
        while (SurvivalTimer.counting != false)
        {
            posNum = Random.Range(0, spawnSpots.Length);
            spawnPos = spawnSpots[posNum];
            carPrefab = Instantiate(car, spawnPos.position, Quaternion.identity, transform);
            if (posNum == 1)
            {
                carPrefab.transform.localScale = new Vector2(-1f, 1f);
            }
            yield return new WaitForSeconds(Random.Range(1f, 4f));
        }
    }
}
