using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SurvivalSceneController : MonoBehaviour
{
    public GameObject themeSong;

    public static int[] levelObstacles = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    string[] intros;
    string selectedIntro;

    //Lose Screen
    public GameObject loseScreen;
    public static bool lost;
    public UnityEvent lose;

    //Extras
    //public GameObject gasTank;
    //public GameObject beans;

    private void Awake()
    {
        Application.targetFrameRate = 300;

        lost = false;

        intros = new string[] { "Intro", "Intro 2", "Intro 3" };
        selectedIntro = intros[Random.Range(0, intros.Length)];

        //Extras
        /*if (PlayerPrefs.GetString("GasUsed", "False") == "True")
        {
            gasTank.SetActive(true);
            beans.SetActive(true);
            PlayerPrefs.SetString("GasUsed", "False");
            int i = PlayerPrefs.GetInt("Gas", 0);
            PlayerPrefs.SetInt("Gas", i - 1);
        }*/
    }

    private void Update()
    {
        LostGame();
    }

    //LoseScreen

    public void SetLoseScreenActive()
    {
        loseScreen.SetActive(true);
    }

    void LostGame()
    {
        if (SurvivalTimer.counting == false)
        {
            if (lost == false)
            {
                lose.Invoke();
                themeSong.SetActive(false);
                lost = true;
                //TimerController.counting = false;
            }
        }
    }

    void Retry()
    {

    }
}
