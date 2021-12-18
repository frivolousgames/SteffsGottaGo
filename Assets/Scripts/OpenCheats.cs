using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCheats : MonoBehaviour
{
    bool started;
    int timeRemaining;
    int clicks;

    bool saved;
    bool succeeded;

    public GameObject cheatMenuButton;

    public AudioSource bonusSound;

    private void OnEnable()
    {
        if(PlayerPrefs.GetInt("Cheats", 0) == 1)
        {
            cheatMenuButton.SetActive(true);
            saved = true;
        }
    }

    public void StartSecretCode()
    {
        if(started == false)
        {
            started = true;
            StartCoroutine("SecretCodeTimer");
            timeRemaining = 1;
        }
        else
        {
            timeRemaining = 1;
            clicks++;
        }
    }

    IEnumerator SecretCodeTimer()
    {
        while(timeRemaining > 0)
        {
            timeRemaining--;
            yield return new WaitForSeconds(1f);
        }
        started = false;
        clicks = 0;
    }

    private void Update()
    {
        if(clicks >= 13)
        {
            succeeded = true;
        }
        else
        {
            succeeded = false;
        }
        if(saved == false)
        {
            if (succeeded == true)
            {
                saved = true;
                PlayerPrefs.SetInt("Cheats", 1);
                cheatMenuButton.SetActive(true);
                bonusSound.Play();
            }
        }
        //Debug.Log("Clicks: " + clicks);
    }
}
