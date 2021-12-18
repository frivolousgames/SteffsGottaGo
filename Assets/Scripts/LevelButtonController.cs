using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    public Button button;

    public Text levelNumText;

    int level;
    int plungers;

    public GameObject plunger_1;
    public GameObject plunger_2;
    public GameObject plunger_3;

    public GameObject confirmBox;

    public static int selectedLevel;
    public static int plungerAmount;

    public GameObject locked;

    bool parsed;

    private void Awake()
    {
        int.TryParse(levelNumText.text, out level);
        SetPlungerAmount();
        SetInteractable();
        //Debug.Log(level + " " + PlayerPrefs.GetInt("Plungers:" + (PlayerPrefs.GetInt("Plungers:" + level, 0) - 1), 0));
    }

    private void Start()
    {
        //Debug.Log(gameObject.name + PlayerPrefs.GetInt("Plungers:" + (PlayerPrefs.GetInt("Plungers:" + level, 0) - 1), 0));
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("CheatLevels", 0) == 1)
        {
            button.interactable = true;
            locked.SetActive(false);
            
        }
        else
        {
            SetInteractable();
        }
        //Debug.Log("Plungers: " + PlayerPrefs.GetInt("Plungers:" + level, 0));
        SetPlungerAmount();
    }

    void SetPlungerAmount()
    {
        if(PlayerPrefs.GetInt("Plungers:" + level, 0) == 1)
        {
            plunger_1.SetActive(true);
            plungers = 1;
        }
        else if (PlayerPrefs.GetInt("Plungers:" + level, 0) == 2)
        {
            plunger_2.SetActive(true);
            plungers = 2;
        }
        else if (PlayerPrefs.GetInt("Plungers:" + level, 0) == 3)
        {
            plunger_3.SetActive(true);
            plungers = 3;
        }
    }

    void SetInteractable()
    {
        if(level > 0)
        {
            //if(PlayerPrefs.GetInt("Plungers:" + (PlayerPrefs.GetInt("Plungers:" + level, 0) - 1), 0) < 2)
            if (/*PlayerPrefs.GetInt("Plungers:" + level, 0) < 2 || */PlayerPrefs.GetInt("Plungers:" + (level - 1), 0) < 2)
            {
                button.interactable = false;
                locked.SetActive(true);
            }
        }    
    }

    public void SetLevel()
    {
        selectedLevel = level;
        plungerAmount = plungers;
        confirmBox.SetActive(true);
        
    }
}
