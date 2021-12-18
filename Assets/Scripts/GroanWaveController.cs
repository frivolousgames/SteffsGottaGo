using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroanWaveController : MonoBehaviour
{
    public void OnParticleSystemStopped()
    {
        gameObject.SetActive(false);
    }
}
