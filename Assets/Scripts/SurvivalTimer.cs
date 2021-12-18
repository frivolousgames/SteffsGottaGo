using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalTimer : MonoBehaviour
{
    public static float time;
    Text timerText;
    public GameObject soiledPanel;

    public static bool counting;

    public Text highScoreText;

    private void Awake()
    {
        time = 0;
        counting = true;
        timerText = GetComponent<Text>();
        timerText.text = ((int)time).ToString();
    }

    private void Update()
    {
        Debug.Log(counting);
        if(counting == true)
        {
            CountUp();
            timerText.text = ((int)time).ToString();
        }

        SetHighScore();
    }

    void CountUp()
    {
        time += 1 * Time.deltaTime;
    }

    void SetHighScore()
    {
        if((int)time > PlayerPrefs.GetInt("SurvivalHighScore", 0))
        {
            PlayerPrefs.SetInt("SurvivalHighScore", (int)time);
        }
        highScoreText.text = "Best: " + PlayerPrefs.GetInt("SurvivalHighScore", 0).ToString();
    }

    public void Lose()
    {
        counting = false;
    }
}
