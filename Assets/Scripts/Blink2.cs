using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink2 : MonoBehaviour
{
    Color startColor;

    public Color darkColor;

    Image im;

    float hue;

    bool blinking;
    public float blinkSpeed;

    private void Awake()
    {
        im = GetComponent<Image>();
        startColor = im.color;
        blinking = true;
        StartCoroutine("Blinking");
    }

    IEnumerator Blinking()
    {
        while (blinking == true)
        {
            im.color = Color.LerpUnclamped(startColor, darkColor, Mathf.PingPong(Time.time * blinkSpeed, 1));
            //Debug.Log("Hue: " + im.color);
            yield return null;
        }
    }
}
