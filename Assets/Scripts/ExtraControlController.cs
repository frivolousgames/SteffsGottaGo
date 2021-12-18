using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraControlController : MonoBehaviour
{
    public Image toggleButton;

    private void Update()
    {
        if (ExtrasBoxController.isSwitching)
        {
            toggleButton.raycastTarget = false;
        }
    }

    public void SetToggleColor()
    {
        if (PlayerPrefs.GetInt(ExtrasBoxController.currentPrefab.name, 0) < 1)
        {
            toggleButton.raycastTarget = false;
            toggleButton.color = Color.gray;

        }
        else
        {
            toggleButton.raycastTarget = true;
            toggleButton.color = Color.black;

        }

        Debug.Log(ExtrasBoxController.currentPrefab.name);
    }
}
