using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public static int selectedLevel;
    int plungerAmount;

    public GameObject p1, p2, p3;

    public AudioSource fart;

    public Text levelText;

    string[] intros;
    public static string selectedIntro;

    private void OnEnable()
    {
        selectedLevel = LevelButtonController.selectedLevel;
        plungerAmount = LevelButtonController.plungerAmount;
        SetPlungers();
        levelText.text = "LEVEL: " + selectedLevel;
        intros = new string[] { "Intro", "Intro 2", "Intro 3" };
        //Debug.Log("Level: " + selectedLevel);
    }

    private void OnDisable()
    {
        p1.SetActive(false);
        p2.SetActive(false);
        p3.SetActive(false);
    }

    private void Update()
    {

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
        PlayerPrefs.SetInt("Level", selectedLevel);
        if (PlayerPrefs.GetInt("HowToPlay", 0) == 0)
        {
            SceneManager.LoadSceneAsync("MainIntro");
        }
        else
        {
            if (PlayerPrefs.HasKey("Peanut " + selectedLevel))
            {
                SceneManager.LoadScene("PeanutIntro");
            }
            else if (PlayerPrefs.HasKey("Turtle " + selectedLevel))
            {
                SceneManager.LoadScene("TurtleheadIntro");
            }
            else
            {
                SceneManager.LoadScene(selectedIntro);
            }
        }
          
    }

    void SetPlungers()
    {
        if(plungerAmount == 1)
        {
            p1.SetActive(true);
        }
        else if(plungerAmount == 2)
        {
            p1.SetActive(true);
            p2.SetActive(true);
        }
        else if(plungerAmount == 3)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
        }
    }
}
