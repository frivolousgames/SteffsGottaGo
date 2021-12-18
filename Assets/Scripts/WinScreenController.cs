using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class WinScreenController : MonoBehaviour
{
    public UnityEvent tallyScores;

    public Text[] scoreTexts;

    public Animator[] anims;

    List<int> scores;

    public AudioSource fart;

    public GameObject nextButton;
    public GameObject plungerScreen;
    Animator anim;

    public UnityEvent swipeSound;

    public Text highScoreText;
    int currentHighScore;

    public GameObject bonusText;
    public AudioSource bonusSound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        StartCoroutine("SetScores");
        currentHighScore = PlayerPrefs.GetInt(MainSceneController.currentLevel.ToString(), 1000);
        highScoreText.text = "Hi: " + currentHighScore;
    }

    IEnumerator SetScores()
    {
        tallyScores.Invoke();
        scores = new List<int>();
        yield return new WaitForSeconds(.1f);
        scores.Add(MainSceneController.tpScore);
        scores.Add(MainSceneController.itemScore);
        scores.Add(MainSceneController.skillScoreMax);
        scores.Add(MainSceneController.timeScore);
        scores.Add(MainSceneController.score);
        yield return new WaitForSeconds(2.3f);
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            anims[i].SetTrigger("bulge");
            fart.Play();
            scoreTexts[i].text = scores[i].ToString();
            yield return new WaitForSeconds(.5f);
        }
        if(MainSceneController.score > currentHighScore)
        {
            GameObject bText;
            bText = Instantiate(bonusText, transform.parent);
            bText.GetComponentInChildren<Text>().text = "New High Score!";
            Instantiate(bonusSound, null);
            highScoreText.text = "Hi: " + MainSceneController.score;
            PlayerPrefs.SetInt(MainSceneController.currentLevel.ToString(), MainSceneController.score);
            yield return new WaitForSeconds(.5f);
        }
        nextButton.SetActive(true);
    }

    public void NextButton()
    {
        anim.SetTrigger("next");
        plungerScreen.SetActive(true);
        swipeSound.Invoke();
    }

    /*void SetScore(Text score)
    {

    }*/
}
