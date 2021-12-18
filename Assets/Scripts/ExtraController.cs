using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraController : MonoBehaviour
{
    public GameObject endButton;

    private void Start()
    {
        if(PlayerPrefs.GetInt("Ending", 0) > 0)
        {
            endButton.SetActive(true);
        }
    }

    public void CloseScreen()
    {
        gameObject.SetActive(false);
    }

    //TEMP
    public void LoadEnding()
    {
        SceneManager.LoadScene("Ending");
    }

    //Buying
    public void AddPurchasedItem()
    {
        int itemAmount = PlayerPrefs.GetInt(PurchaseButton.selectedBuyObject, 0);
        PlayerPrefs.SetInt(PurchaseButton.selectedBuyObject, PurchaseButton.selectedBuyAmount + itemAmount);
        Debug.Log("Added: " + PurchaseButton.selectedBuyObject + " " + PlayerPrefs.GetInt(PurchaseButton.selectedBuyObject, 0));
        Debug.Log("Bought " + gameObject.name);
    }
}
