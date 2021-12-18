using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeMeter : MonoBehaviour
{
    Slider lifeAmount;
    public Image fillColor;
    public Color fill;
    public Color empty;
    public float redThreshold;

    private void Awake()
    {
        lifeAmount = GetComponent<Slider>();
    }

    private void Update()
    {
        if(lifeAmount.value < redThreshold)
        {
            fillColor.color = empty;
        }
        else
        {
            fillColor.color = fill;
        }
    }
}
