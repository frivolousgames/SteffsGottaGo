using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetButtonsActive : MonoBehaviour
{
    public GameObject buts;

    public void SetActive()
    {
        if(buts.activeInHierarchy == false)
        {
            buts.SetActive(true);
        }
    }

}
