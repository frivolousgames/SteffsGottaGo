using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    string phrase1;
    string phrase2;
    string phrase3;
    string phrase4;

    string[] phrases;

    public Text headingText;

    Animator anim;

    int clicks;

    public GameObject nextButton;
    public GameObject restartButton;
    public GameObject quitButton;

    bool main;

    public GameObject eventSys;
    public AudioListener listener;

    private void Awake()
    {

        anim = GetComponent<Animator>();

        phrase1 = "USE THE DUCK AND JUMP BUTTONS TO DODGE ONCOMING OBSTACLES";
        phrase2 = "COLLECT ITEMS FOR EXTRA POINTS AND BONUSES. STEFF COINS CAN BE USED AT THE \nSHART TANK\u2122";
        phrase3 = "REACH THE TOILET BEFORE TIME RUNS OUT TO KEEP STEFF FROM SOILING HERSELF";
        phrase4 = "USE POWER-UPS TO GET THROUGH TOUGH LEVELS. EACH ONE UNLOCKS A SPECIAL ABILITY";

        phrases = new string[] { phrase1, phrase2, phrase3, phrase4 };
    }

    private void Start()
    {
        nextButton.SetActive(true);
        restartButton.SetActive(false);
        quitButton.SetActive(false);
        headingText.text = phrases[clicks];

        if(SceneManager.sceneCount == 1)
        {
            eventSys.SetActive(true);
            listener.enabled = true;
        }
        else
        {
            eventSys.SetActive(false);
            listener.enabled = false;
        }
    }

    private void Update()
    {
        headingText.text = phrases[clicks];
    }

    public void Next()
    {
        anim.SetTrigger("next");
        clicks++;
        if (clicks > 2)
        {
            nextButton.SetActive(false);
            restartButton.SetActive(true);
            quitButton.SetActive(true);
        }
    }

    public void Restart()
    {
        anim.SetTrigger("next");
        clicks = 0;
        nextButton.SetActive(true);
        restartButton.SetActive(false);
        quitButton.SetActive(false);
    }

    public void Quit()
    {
        if(PlayerPrefs.GetInt("HowToPlay", 0) == 0)
        {
            int level = PlayerPrefs.GetInt("Level", 0);
            PlayerPrefs.SetInt("HowToPlay", 1);
            if (PlayerPrefs.HasKey("Peanut " + level))
            {
                SceneManager.LoadScene("PeanutIntro");
            }
            else if (PlayerPrefs.HasKey("Turtle " + level))
            {
                SceneManager.LoadScene("TurtleheadIntro");
            }
            else
            {
                SceneManager.LoadScene("Main");
            }
        }
        else
        {
            SceneManager.UnloadSceneAsync("HowToPlay");
        }

    }
}
