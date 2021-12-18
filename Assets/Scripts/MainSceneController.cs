using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class MainSceneController : MonoBehaviour
{
    //TP Amount
    public static int tpAmount;
    Text tpAmountText;

    //AmmoAmount
    public static int ammoAmount;
    public Text ammoAmountText;

    //Item Amount
    public static int itemAmount;

    //Falls
    public static int falls;
    public static bool perfect;

    //Win
    public static int winThreshold;
    public static bool won;
    public GameObject pop;
    public static bool popActive = true;

    public GameObject themeSong;

    //Win Screen
    public GameObject winScreen;

    //Lose Screen
    public GameObject loseScreen;
    public static bool lost;
    public UnityEvent lose;
    //public AudioSource themeMusic;

    //Plunger Screen
    public static int plungerAmount;

    //Score
    public static int score;
    public static int skillScoreMax;
    public static int timeScore;
    public static int itemScore;
    public static int tpScore;

    //Bonus
    public static string bonusText;

    //Shart
    public static int shartNumber;
    public static string shartLetter;
    public static int shartCollected;
    public UnityEvent shartAchieved;
    public static bool shartTime;
    public static bool shartCancel;
    public UnityEvent shartCancelled;
    public GameObject shartLetterHolder;
    public GameObject[] shartCountLetters;

    //Levels

    public static int currentLevel;
    public static int nextLevel;

    public static int[] selectedObstacles;
    List<int[]> levelObstacles;
    public static int levelObstaclesLength;

    string[] intros;
    string selectedIntro;

    //Alternate Intros
    public static string turtleIntro;
    public static string peanutIntro;

    //Alternate Levels
    public GameObject turtleheadButton;

    public GameObject spitButton;
    public GameObject peanutAmountText;
    public GameObject balloonSpawner;
    public GameObject peanuts;

    public GameObject jumpArea;
    public GameObject gasJumpArea;

    //PauseMenu
    public GameObject inGameMenu;
    public GameObject extraController;

    int[] l_0 = {0,1,2,3,4,5};
    int[] l_1 = {0,1,2,3,4,5};
    int[] l_2 = {1,2,3,4,5,7,14};
    int[] l_3 = {1,2,3,4,5,7,14};
    int[] l_4 = {1,2,3,4,5,6};
    int[] l_5 = {2,3,4,5,6,8,14};
    int[] l_6 = {2,3,4,5,6,7,14};
    int[] l_7 = {0,3,4,5,6,7};
    int[] l_8 = {3,5,6,7,8,13};
    int[] l_9 = {1,3,5,6,7,8,13};
    int[] l_10 = {0,4,5,6,7,8,9};
    int[] l_11 = {2,5,6,7,8,9,14};
    int[] l_12 = {0,5,6,7,8,9,10};
    int[] l_13 = {3,6,7,8,9,10,13};
    int[] l_14 = {6,7,8,9,10,11,14};
    int[] l_15 = {4,7,8,9,10,11,13};
    int[] l_16 = {7,8,9,10,11,12,13};
    int[] l_17 = {8,9,10,11,12};
    int[] casual = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};


    /*
    high: 2, 3, 6, 7, 14
    low: 0, 1, 4, 5, 8, 9, 10, 13
    mix: 11, 12
         */

    //Extras
    public GameObject gasTank;
    public GameObject beans;

    public GameObject groanMeter;

    public GameObject monkeyButton;
    public GameObject monkey;

    //public GameObject monkey;

    private void Awake()
    {
        //TEMP//////////////////////////

        //PlayerPrefs.SetInt("Level", 16);
        //PlayerPrefs.SetInt("Plungers:2", 0);
        //PlayerPrefs.SetInt("Plungers:4", 0);
        //PlayerPrefs.DeleteAll();

        /////////////////////////////////
        Application.targetFrameRate = 300;

        winThreshold = 100;
        tpAmount = 0;
        ammoAmount = 0;
        itemAmount = 0;
        falls = 0;
        perfect = false;
        won = false;
        lost = false;
        popActive = false;
        plungerAmount = 0;
        score = 0;
        skillScoreMax = 1000;
        timeScore = 0;
        itemScore = 0;
        tpScore = 0;
        shartNumber = 1;
        shartCollected = 0;
        shartTime = false;
        shartCancel = false;
        bonusText = "";

        levelObstacles = new List<int[]>();

        levelObstacles.Add(l_0);
        levelObstacles.Add(l_1);
        levelObstacles.Add(l_2);
        levelObstacles.Add(l_3);
        levelObstacles.Add(l_4);
        levelObstacles.Add(l_5);
        levelObstacles.Add(l_6);
        levelObstacles.Add(l_7);
        levelObstacles.Add(l_8);
        levelObstacles.Add(l_9);
        levelObstacles.Add(l_10);
        levelObstacles.Add(l_11);
        levelObstacles.Add(l_12);
        levelObstacles.Add(l_13);
        levelObstacles.Add(l_14);
        levelObstacles.Add(l_15);
        levelObstacles.Add(l_16);
        levelObstacles.Add(l_17);
        levelObstacles.Add(casual);

        /*levelObstacles.Add(l_18);
        levelObstacles.Add(l_19);
        levelObstacles.Add(l_20);*/

        currentLevel = PlayerPrefs.GetInt("Level", 0);
        selectedObstacles = levelObstacles[currentLevel];
        levelObstaclesLength = levelObstacles.Count;

        //Alternate Intros
        /*PlayerPrefs.SetString("Peanut 4", "True");
        PlayerPrefs.SetString("Turtle 8", "True");
        PlayerPrefs.SetString("Turtle 13", "True");
        PlayerPrefs.SetString("Turtle 17", "True");*/

        //Alternate Levels
        CheckIfAlternate();

        //Alternate Intros
        intros = new string[] { "Intro", "Intro 2", "Intro 3" };
        //Debug.Log("Gas Pre: " + PlayerPrefs.GetInt("Gas", 0));

        //Extras
        if (PlayerPrefs.GetString("GasUsed", "False") == "True")
        {
            gasTank.SetActive(true);
            beans.SetActive(true);
            jumpArea.SetActive(false);
            gasJumpArea.SetActive(true);
            PlayerPrefs.SetString("GasUsed", "False");
            if(PlayerPrefs.GetInt("CheatPUs", 0) == 0)
            {
                int i = PlayerPrefs.GetInt("Gas", 0);
                PlayerPrefs.SetInt("Gas", i - 1);
            }
            Debug.Log("Gas Post: " + PlayerPrefs.GetInt("Gas", 0));
        }
        if (PlayerPrefs.GetString("GroanUsed", "False") == "True")
        {
            groanMeter.SetActive(true);
            PlayerPrefs.SetString("GroanUsed", "False");
            if (PlayerPrefs.GetInt("CheatPUs", 0) == 0)
            {
                int i = PlayerPrefs.GetInt("Groan", 0);
                PlayerPrefs.SetInt("Groan", i - 1);
            }
            Debug.Log("Groan Post: " + PlayerPrefs.GetInt("Groan", 0));
        }
        if (PlayerPrefs.GetString("BombsUsed", "False") == "True")
        {
            monkey.SetActive(true);
            monkeyButton.SetActive(true);
            PlayerPrefs.SetString("BombsUsed", "False");
            if (PlayerPrefs.GetInt("CheatPUs", 0) == 0)
            {
                int i = PlayerPrefs.GetInt("Bombs", 0);
                PlayerPrefs.SetInt("Bombs", i - 1);
            }    
            Debug.Log("Bombs Post: " + PlayerPrefs.GetInt("Bombs", 0));
        }

    }

    void Start()
    {
        //TP Amount
        tpAmountText = GameObject.FindGameObjectWithTag("TpAmount").GetComponent<Text>();

        //Ammo Amount
        //ammoAmountText = GameObject.FindGameObjectWithTag("AmmoAmount").GetComponent<Text>();

        //Win
        //100;
        //winThreshold = PlayerPrefs.GetInt('level speed');
        if (shartLetterHolder.activeInHierarchy)
        {
            if (groanMeter.activeInHierarchy || monkeyButton.activeInHierarchy || gasTank.activeInHierarchy)
            {
                shartLetterHolder.transform.localPosition = new Vector2(shartLetterHolder.transform.localPosition.x, shartLetterHolder.transform.localPosition.y - 100);
            }
        }
    }

    private void Update()
    {
        //TP Amount
        tpAmountText.text = tpAmount.ToString();
        ammoAmountText.text = ammoAmount.ToString();
        FallCounter();
        ActivatePop(CameraMover.distance, winThreshold);
        WinLevel();
        LostGame();

        //ShartTank
        ShartTankAchieved();
        ActivateShartTank();
        ShartNotActivated();
        SetShartCollectedLetter();

        Debug.Log("Level: " + currentLevel);
        /*foreach(int i in selectedObstacles)
        {
            Debug.Log("Selected: " + i);
        }*/
        
        //Debug.Log("bonusText: " + bonusText);
    }

    void ActivatePop(int amount, int winThreshold)
    {
        if (amount == winThreshold)
        {
            pop.SetActive(true);
            popActive = true;
            if (inGameMenu.activeInHierarchy == true)
            {
                inGameMenu.SetActive(false);
                extraController.SetActive(false);
            }
        }
    }

    void WinLevel()
    {
        if (DoorClose.stopped == true && !loseScreen.activeInHierarchy && lost == false)
        {
            CameraMover.isMoving = false;
            won = true;
            TimerController.counting = false;
            themeSong.SetActive(false);
        }
    }

    void FallCounter()
    {
        if(falls < 1)
        {
            perfect = true;
        }
        else
        {
            perfect = false;
        }
    }

    //Win Screen

    public void SetWinScreenActive()
    {
        winScreen.SetActive(true);
    }

    //LoseScreen

    public void SetLoseScreenActive()
    {
        loseScreen.SetActive(true);
    }

    void LostGame()
    {
        if(TimerController.maxTime < 1 || TurtleheadController.lost == true)
        {
            if (lost == false && won == false)
            {
                lose.Invoke();
                themeSong.SetActive(false);
                lost = true;
                if(inGameMenu.activeInHierarchy == true)
                {
                    inGameMenu.SetActive(false);
                    extraController.SetActive(false);
                }
                //TimerController.counting = false;
            }
        } 
    }

    //Score

    public void SetScores()
    {
        //Skill
        for(int i = falls; i > 0; i--)
        {
            if(skillScoreMax > 100)
            {
                skillScoreMax -= 100;
            }
        }
        //Time
        timeScore = (int)TimerController.maxTime * 50;
        //TP
        tpScore = tpAmount * 100;
        //Item
        itemScore = itemAmount * 100;
        //Total
        score = skillScoreMax + timeScore + tpScore + itemScore;
    }

    //Plunger Screen

    public void SetPlungerAmount()
    {
        if(score >= 2000)
        {
            plungerAmount = 3;
            PlayerPrefs.SetInt("Plungers:" + currentLevel, 3);
        }
        else if( score < 2000 && score >= 1600)
        {
            plungerAmount = 2;
            if(PlayerPrefs.GetInt("Plungers:" + currentLevel, 0) < plungerAmount)
            {
                PlayerPrefs.SetInt("Plungers:" + currentLevel, 2);
            }
        }
        else
        {
            plungerAmount = 1;
            if (PlayerPrefs.GetInt("Plungers:" + currentLevel, 0) < plungerAmount)
            {
                PlayerPrefs.SetInt("Plungers:" + currentLevel, 1);
            }

        }
    }

    public void SetLevel()
    {
        selectedIntro = intros[Random.Range(0, intros.Length)];
        int i = PlayerPrefs.GetInt("Level", 0);
        if (i < levelObstacles.Count - 2)
        {
            PlayerPrefs.SetInt("Level", i + 1);
            currentLevel = PlayerPrefs.GetInt("Level", 0);
            Debug.Log("Level Up: " + PlayerPrefs.GetInt("Level", 0));
            if (PlayerPrefs.HasKey("Peanut " + currentLevel))
            {
                SceneManager.LoadScene("PeanutIntro");
            }
            else if (PlayerPrefs.HasKey("Turtle " + currentLevel))
            {
                SceneManager.LoadScene("TurtleheadIntro");
            }
            else
            {
                SceneManager.LoadScene(selectedIntro);
            }
        }
        else if(i < levelObstacles.Count - 1 && i > levelObstacles.Count - 3)
        {
            SceneManager.LoadScene("Ending");
            PlayerPrefs.SetString("End", "True");
            Debug.Log("Game Over");
            //Game Over
        }
        else
        {
            SceneManager.LoadScene(selectedIntro);
        }
    }

    //Alternate Levels

    void CheckIfAlternate()
    {
        if (PlayerPrefs.HasKey("Peanut " + currentLevel))
        {
            peanutAmountText.SetActive(true);
            spitButton.SetActive(true);
            peanuts.SetActive(true);
            balloonSpawner.SetActive(true);
            shartLetterHolder.SetActive(true);
            
        }
        else if (PlayerPrefs.HasKey("Turtle " + currentLevel))
        {
            turtleheadButton.SetActive(true);
        }
    }

    //ShartTank
    
    void SetShartCollectedLetter()
    {
        if(shartCollected > 0)
        {
            shartCountLetters[shartCollected - 1].SetActive(true);
        } 
    }
    
    bool ShartTankAchieved()
    {
        if(shartCollected == 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void ActivateShartTank()
    {
        if(ShartTankAchieved() == true)
        {
            shartAchieved.Invoke();
            shartCollected = 0;
            shartCountLetters[4].SetActive(true);
            shartTime = true;
            if (PlayerPrefs.GetString("ShartTank", "False") == "False")
            {
                bonusText = "Shart Tank Unlocked!";
                PlayerPrefs.SetString("ShartTank", "True");
            }
            else
            {
                bonusText = "";
            }
            StartCoroutine("DeLetter");
        }
    }

    IEnumerator DeLetter()
    {
        yield return new WaitForSeconds(1f);
        shartLetterHolder.SetActive(false);
    }
    void ShartNotActivated()
    {
        if(shartCancel == true)
        {
            shartCancelled.Invoke();
            balloonSpawner.SetActive(false);
            ObstacleSpawner.peanutTime = 0f;
            GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");
            foreach(GameObject balloon in balloons)
            {
                Destroy(balloon);
            }
            if(PlayerPrefs.GetString("ShartTank", "False") == "False")
            {
                bonusText = "Shart Tank Not Unlocked!";
            }
            else
            {
                bonusText = "";
            }
            shartLetterHolder.SetActive(false);
            shartCancel = false;
            Debug.Log("Shart Cancelled");
        }
    }
}

    
