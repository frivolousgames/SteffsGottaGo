using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowToSurvival : MonoBehaviour
{

    public void Quit()
    {
        PlayerPrefs.SetInt("HowToSurvival", 1);
        SceneManager.LoadScene("Survival");
    }
}
