using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWinSound : MonoBehaviour
{
    public AudioSource winSound;

    public void PlaySound()
    {
        winSound.Play();
    }
}
