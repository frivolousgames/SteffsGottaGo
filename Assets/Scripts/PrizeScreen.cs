using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PrizeScreen : MonoBehaviour
{
    public Text[] amountText;

    int amountPrevious;
    int amount;

    string chosenExtra;

    public GameObject acceptSound;
    public GameObject acceptText;

    public Transform acceptSpawn;

    public UnityEvent reset;

    private void OnEnable()
    {
        amountPrevious = PlayerPrefs.GetInt("PrizeAmount", 1);
        SetAmountText();
    }

    void SetAmountText()
    {
        if(amountPrevious % 5 == 0)
        {
            amount = 10;
        }
        else
        {
            amount = 3;
        }
        //Debug.Log("Amount: " + amount);
        foreach (Text t in amountText)
        {
            t.text = "x" + amount.ToString();
        }

        //Debug.Log("AmountPrevious: " + amountPrevious);
    }

    public void AcceptPrize()
    {
        chosenExtra = ExtraScreenButton.chosenExtra;
        int i = PlayerPrefs.GetInt(chosenExtra, 0);
        PlayerPrefs.SetInt(chosenExtra, i + amount);
        Instantiate(acceptSound, null);
        GameObject pre = Instantiate(acceptText, acceptSpawn);
        pre.GetComponentInChildren<Text>().text = amount + " " + chosenExtra + " Added!";
        PlayerPrefs.SetInt("PrizeAmount", amountPrevious + 1);
        reset.Invoke();
        gameObject.SetActive(false);

    }
}
