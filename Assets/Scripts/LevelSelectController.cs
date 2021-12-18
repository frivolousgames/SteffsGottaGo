using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{
    //ShartButton
    public Image shartIm;
    public Color shartEColor;
    public Color shartDColor;

    public GameObject shartLockObj;

    //EndSceneButton
    public Image endIm;
    public Color endEColor;
    public Color endDColor;

    public GameObject endLockObj;

    //Coins
    public Text coinText;

    //RateBox
    public GameObject rateBox;
    string playStoreLink = "https://play.google.com/store/apps/details?id=com.FrivoulousGames.SteffsGottaGo&hl=en_US&gl=US";

    private void Awake()
    {
        CheckButton("ShartTank", shartIm, shartLockObj, shartEColor, shartDColor);
        CheckButton("End", endIm, endLockObj, endEColor, endDColor);

        CheckCoins();

        //Alternate Intros
        PlayerPrefs.SetString("Turtle 4", "True");
        PlayerPrefs.SetString("Peanut 8", "True");
        PlayerPrefs.SetString("Turtle 12", "True");
        PlayerPrefs.SetString("Turtle 17", "True");
    }

    private void Start()
    {
        //PlayerPrefs.SetInt("RateTime", 0);
        EnableRateBox();
    }

    private void Update()
        
    {
        CheckCheatButton("ShartTank", shartIm, shartLockObj, shartEColor, shartDColor);
        CheckCheatButton("End", endIm, endLockObj, endEColor, endDColor);
        CheckCoins();
        //Debug.Log(PlayerPrefs.GetInt("RateTime", 0));
    }

    void CheckButton(string name, Image im, GameObject lockObj, Color eColor, Color dColor)
    {
        if(PlayerPrefs.GetString(name, "False") == "True")
        {
            im.raycastTarget = true;
            im.color = eColor;
            lockObj.SetActive(false);
        }
        else
        {
            im.raycastTarget = false;
            im.color = dColor;
            lockObj.SetActive(true);
        }
    }
    
    void CheckCheatButton(string name, Image im, GameObject lockObj, Color eColor, Color dColor)
    {
        if (PlayerPrefs.GetInt("Cheat" + name, 0) == 1)
        {
            im.raycastTarget = true;
            im.color = eColor;
            lockObj.SetActive(false);
        }
        else
        {
            CheckButton(name, im, lockObj, eColor, dColor);
        }
    }

    //Coins
    void CheckCoins()
    {
        if(PlayerPrefs.GetInt("CheatCoins", 0) == 1 || PlayerPrefs.GetInt("Coins", 0) > 999)
        {
            coinText.text = "999+";
        }
        else
        {
            coinText.text = PlayerPrefs.GetInt("Coins", 0).ToString();
        }
        
    }

    //RateBox
    void EnableRateBox()
    {
        if(PlayerPrefs.GetInt("RateTime", 0) == 3)
        {
            rateBox.SetActive(true);
            PlayerPrefs.SetInt("RateTime", 0);
        }
        else
        {
            int i = PlayerPrefs.GetInt("RateTime", 0);
            PlayerPrefs.SetInt("RateTime", ++i);
        }
    }
    public void RateApp()
    {
        Application.OpenURL(playStoreLink);
        PlayerPrefs.SetInt("RateTime", 10);
        rateBox.SetActive(false);
    }
    public void AskLater()
    {
        rateBox.SetActive(false);
    }
}
