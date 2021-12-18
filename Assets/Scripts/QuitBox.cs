using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBox : MonoBehaviour
{
    public GameObject box;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Cancel()
    {
        box.SetActive(false);
    }
}
