using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameobject : MonoBehaviour
{
    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
