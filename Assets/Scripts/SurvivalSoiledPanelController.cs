using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SurvivalSoiledPanelController : MonoBehaviour
{
    //string[] intros;
    //string selectedIntro;

    public Text timeText;

    //public GameObject extraScreen;

    private void Awake()
    {
        //intros = new string[] { "Intro", "Intro 2", "Intro 3" };
        //selectedIntro = intros[Random.Range(0, intros.Length)];
        //StartCoroutine("ExtraActive");
    }

    private void Start()
    {
        timeText.text = "Time: " + ((int)SurvivalTimer.time).ToString();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Survival");
    }

    public void Quit()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    /*IEnumerator ExtraActive()
    {
        yield return new WaitForSeconds(1f);
        extraScreen.SetActive(true);
    }*/
}
