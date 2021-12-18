using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOnEnable : MonoBehaviour
{
    public GameObject extraControl;

    private void OnEnable()
    {
        extraControl.SetActive(true);
    }

    private void OnDisable()
    {
        extraControl.SetActive(false);
    }
}
