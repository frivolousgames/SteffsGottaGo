using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    Color startColor;
    Color defaultColor;

    public Color darkColor;
    public Color brightColor;

    Image im;

    float hue;

    bool blinking;
    public float blinkSpeed;

    private void Awake()
    {
        im = GetComponent<Image>();
        startColor = im.color;
    }

    private void Update()
    {
        if(PlayerPrefs.GetInt("Coins", 0) > 0)
        {
            defaultColor = brightColor;
        }
        else
        {
            defaultColor = startColor;
        }
        im.color = defaultColor;
    }

    public void ChangeColor()
    {
        if(blinking == false)
        {
            StartCoroutine("Blinking");
        }
    }

    IEnumerator Blinking()
    {
        blinking = true;
        while (GrabberController.working == true)
        {
            im.color = Color.LerpUnclamped(darkColor, brightColor, Mathf.PingPong(Time.time * blinkSpeed, 1) );
            //Debug.Log("Hue: " + im.color);
            yield return null;
        }
        im.color = defaultColor;
        blinking = false;
    }
}
