using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpSound : MonoBehaviour
{
    public AudioSource tpSound;

    public void PlaySound()
    {
        tpSound.Play();
    }
}
