using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurvivalPlay : MonoBehaviour
{
    public AudioSource fart;

    public void Play()
    {
        fart.Play();
        StartCoroutine("FartWait");
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }

    IEnumerator FartWait()
    {
        while (fart.isPlaying)
        {
            yield return null;
        }
        if (PlayerPrefs.GetInt("HowToSurvival", 0) == 0)
        {
            SceneManager.LoadScene("HowToSurvival");
        }
        else
        {
            SceneManager.LoadScene("Survival");
        }
    }
}
