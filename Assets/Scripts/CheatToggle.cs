using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatToggle : MonoBehaviour
{
    public GameObject onText;
    public GameObject offText;

    Color onColor;
    Color offColor;

    Image bg;

    bool isOn;

    public GameObject acceptSound;
    public GameObject clickSound;

    private void Awake()
    {
        bg = GetComponent<Image>();
        offColor = Color.black;
        onColor = new Color32(0, 203, 140, 255);
    }

    private void OnEnable()
    {
        if(PlayerPrefs.GetInt("Cheat" + gameObject.name, 0) == 1)
        {
            isOn = true;
            onText.SetActive(true);
            offText.SetActive(false);
            transform.rotation = new Quaternion(0f, 0f, 180f, 1f);
            bg.color = onColor;
        }
        else
        {
            isOn = false;
            onText.SetActive(false);
            offText.SetActive(true);
            transform.rotation = Quaternion.identity;
            bg.color = offColor;
        }
    }
    public void Switch()
    {
        if (offText.activeInHierarchy == true)
        {
            onText.SetActive(true);
            offText.SetActive(false);
            transform.rotation = new Quaternion(0f, 0f, 180f, 1f);
            bg.color = onColor;
            Instantiate(acceptSound, null);
            isOn = true;
            PlayerPrefs.SetInt("Cheat" + gameObject.name, 1);
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
        PlayerPrefs.SetInt("Cheat" + gameObject.name, 0);
        isOn = false;
    }
}
