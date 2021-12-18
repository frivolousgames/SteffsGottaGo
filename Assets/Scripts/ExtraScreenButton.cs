using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraScreenButton : MonoBehaviour
{
    public static string chosenExtra;
    public GameObject extraName;

    public void SetExtra()
    {
        chosenExtra = extraName.name;
    }
}
