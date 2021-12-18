using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public GameObject onText;
    public GameObject offText;

    Color onColor;
    Color offColor;

    Image bg;

    public static bool isOn;

    public GameObject acceptSound;
    public GameObject clickSound;

    private void Awake()
    {
        bg = GetComponent<Image>();
        offColor = Color.black;
        onColor = new Color32(0, 203, 140, 255);
        isOn = false;
    }

    private void OnEnable()
    {
        Off();
        isOn = false;
    }
    public void Switch()
    {
        if(offText.activeInHierarchy == true)
        {
            onText.SetActive(true);
            offText.SetActive(false);
            transform.rotation = new Quaternion(0f, 0f, 180f, 1f);
            bg.color = onColor;
            Instantiate(acceptSound, null);
            isOn = true;
        }
        else
        {
            Off();
        }
    }
    public void SwitchOff()
    {
        Off();
    }

    void Off()
    {
        onText.SetActive(false);
        offText.SetActive(true);
        transform.rotation = Quaternion.identity;
        bg.color = offColor;
        Instantiate(clickSound, null);
        isOn = false;
    }
}
