using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactive : MonoBehaviour
{
    public GameObject obj;

     public void SetObjInactive()
    {
        if(obj.activeInHierarchy == true)
        {
            obj.SetActive(false);
        }
    }
}
