using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class PurchaseResult : MonoBehaviour
{
    public GameObject purchaseResultBox;
    public Text purchaseResultText;
    public Text purchaseResultTextHeader;

    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {
        purchaseResultBox.SetActive(true);

        string errorMessage = "Error: Purchase not completed\nPlease try again\nReason: " + p.ToString();
        purchaseResultText.text = errorMessage;
        purchaseResultTextHeader.text = "FAILED";
    }

    public void OnPurchaseComplete(Product i)
    {
        purchaseResultBox.SetActive(true);

        string successMessage = "Purchased: " + PurchaseButton.selectedBuyAmount.ToString() + " " + PurchaseButton.selectedBuyObject;
        purchaseResultText.text = successMessage;
        purchaseResultTextHeader.text = "SUCCESS";
    }
}
