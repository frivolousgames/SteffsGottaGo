using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dazed : MonoBehaviour
{
    public GameObject dazedRing;
    public UnityEvent dizzyEvent;

    public void DazeRing()
    {
        if(MainSceneController.lost == false || SurvivalSceneController.lost == false)
        {
            if(dazedRing != null)
            {
                dazedRing.SetActive(true);
                AudioController.psIndex = 4;
            }
            dizzyEvent.Invoke();
        }
    }
}
