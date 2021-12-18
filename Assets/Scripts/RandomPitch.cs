using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPitch : MonoBehaviour
{
    AudioSource a;

    public float min;
    public float max;

    private void Awake()
    {
        a = GetComponent<AudioSource>();
        a.pitch = Random.Range(min, max);
    }

}
