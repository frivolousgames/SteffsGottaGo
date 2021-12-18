using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFart : MonoBehaviour
{
    public GameObject buttonFart;

    public void FartSound()
    {
        Instantiate(buttonFart, null);
    }
}
