using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class TimerController : MonoBehaviour
{
    public static float maxTime;
    Text timerText;
    //TextMeshPro timerText;
    public GameObject soiledPanel;

    public static bool counting;


    private void Awake()
    {
        maxTime = 60;
        counting = true;
        //timerText = GetComponent<TextMeshPro>();
        timerText = GetComponent<Text>();
        timerText.text = ((int)maxTime).ToString();
    }

    private void Update()
    {
        
        CountingDown();
    }

    void CountingDown()
    {
        if (counting == true)
        {
            if (maxTime > 1)
            {
                if (TurtleheadController.lost == true)
                {
                    timerText.text = "Breach!";
                    counting = false;
                }
                else
                {
                    maxTime -= 1 * Time.deltaTime;
                    timerText.text = ((int)maxTime).ToString();
                }
                
            }
            else
            {
                timerText.text = "Time Up";
                Debug.Log("Timeup");
                counting = false;
                //fart sounds
            }
        }
    }
}
