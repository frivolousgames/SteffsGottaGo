using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public GameObject objectName;
    public GameObject objectAmount;

    public static string selectedBuyObject;
    public static int selectedBuyAmount;

    private void Update()
    {
        Debug.Log(selectedBuyObject);
    }

    public void SelectBuyObject()
    {
        selectedBuyObject = objectName.name;
        int.TryParse(objectAmount.name, out selectedBuyAmount);
    }

    
}
