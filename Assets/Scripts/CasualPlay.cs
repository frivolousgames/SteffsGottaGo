using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CasualPlay : MonoBehaviour
{
    public AudioSource fart;

    public int casual; //Change When Adding Levels

    string[] intros;
    string selectedIntro;

    private void Awake()
    {
        intros = new string[] { "Intro", "Intro 2", "Intro 3" };
    }

    public void Play()
    {
        fart.Play();
        selectedIntro = intros[Random.Range(0, intros.Length)];
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

        PlayerPrefs.SetInt("Level", casual);
        if (PlayerPrefs.GetInt("HowToPlay", 0) == 0)
        {
            SceneManager.LoadSceneAsync("HowToPlay");
        }
        else
        {
            SceneManager.LoadScene(selectedIntro);
        }
    }
}
