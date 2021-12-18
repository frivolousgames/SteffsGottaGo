using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetExtraAmountText : MonoBehaviour
{
    public string extraName;
    Text amountText;

    private void Awake()
    {
        amountText = GetComponent<Text>();
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("CheatPUs", 0) == 0)
        {
            if (PlayerPrefs.GetInt(extraName, 0) < 100)
            {
                amountText.text = "x" + PlayerPrefs.GetInt(extraName, 0).ToString();
            }
            else
            {
                amountText.text = "x" + "99+";
            }
            //Debug.Log("Cheat False");
        }
        else
        {
            amountText.text = "x" + "99+";
            //Debug.Log("Cheat True");
        }
    }
}
