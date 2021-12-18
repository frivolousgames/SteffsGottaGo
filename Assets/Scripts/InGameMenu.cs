using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject inGameMenu;
    public GameObject extraController;

    string[] intros;
    public static string selectedIntro;

    private void Awake()
    {
        intros = new string[] { "Intro", "Intro 2", "Intro 3" };
    }

    public void Pause()
    {
        if(TimerController.counting == true && MainSceneController.lost == false && MainSceneController.won == false && MainSceneController.popActive == false)
        {
            if (inGameMenu.activeInHierarchy == false)
            {
                inGameMenu.SetActive(true);
                extraController.SetActive(true);
            }
            else
            {
                inGameMenu.SetActive(false);
                extraController.SetActive(false);
            }
        }
    }

    public void Restart()
    {
        CameraMover.isMoving = false;
        TimerController.counting = false;
        selectedIntro = intros[Random.Range(0, intros.Length)];
        SceneManager.LoadScene(selectedIntro);
    }

    public void Quit()
    {
        CameraMover.isMoving = false;
        TimerController.counting = false;
        SceneManager.LoadScene("LevelSelect");
    }
}
