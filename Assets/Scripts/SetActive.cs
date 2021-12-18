using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject obj;

    public void SetObjActive()
    {
        if(obj.activeInHierarchy== false)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }
}
