using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    public AudioSource step;

    public void Step()
    {
        step.pitch = Random.Range(.8f, 1.2f);
        step.Play();
    }
}
