using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullsizeClick : MonoBehaviour
{
    int indexText;

    public void Clicked()
    {
        if(int.TryParse(GetComponentInChildren<Text>().text, out indexText) == true)
        {
            UnlockableScreen.selectedItem = indexText;
            UnlockableScreen.fullScreenItem.SetActive(true);
        }
    }
}
