using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopBallShooter : MonoBehaviour
{
    public GameObject poopBall;

    public Transform pbSpawn;

    public void SpawnBall()
    {
        Instantiate(poopBall, pbSpawn.position, Quaternion.identity, transform.parent);
    }
}
