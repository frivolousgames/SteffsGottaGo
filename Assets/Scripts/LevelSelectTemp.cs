using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectTemp : MonoBehaviour
{
    /*private void Awake()
    {
        PlayerPrefs.SetInt("Gas", 3);
        PlayerPrefs.SetInt("Groan", 3);
        PlayerPrefs.SetInt("Bombs", 3);
    }*/

    public void LoadShart()
    {
        SceneManager.LoadScene("ShartTank");
    }

}
