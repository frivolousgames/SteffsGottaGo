using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtleheadController : MonoBehaviour
{
    public Slider head;

    public float headGain;
    public float clickLoss;

    bool clicked;
    public float clickWait;

    public float shakeThresh;
    public bool shakeTime;

    public Animator headAnim;

    public Image sr;

    public float glowTime;
    bool glowReady;

    Color oColor;

    public GameObject shell;
    Animator shellAnim;
    Image shellImage;

    public static bool lost;

    public GameObject strain;
    GameObject strainPrefab;

    public GameObject gasMeter;
    public GameObject groanMeter;
    public GameObject monkeyButton;
    public float posAdjust;

    public AudioSource tapSound;

    private void Awake()
    {
        lost = false;
    }

    private void Start()
    {
        shellAnim = shell.GetComponent<Animator>();
        shellImage = shell.GetComponent<Image>();
        oColor = sr.color;
        shellAnim.speed = .4f;
        if(gasMeter.activeInHierarchy == true || groanMeter.activeInHierarchy == true || monkeyButton.activeInHierarchy == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - posAdjust);
        }
    }

    private void Update()
    {
        if(MainSceneController.lost == false && MainSceneController.won == false)
        {
            HeadGrow();
            ShakeTime();
            Glow();
        }
        else
        {
            shakeTime = false;
            shellAnim.speed = 0f;
            shellImage.raycastTarget = false;
            if (strainPrefab != null)
            {
                Destroy(strainPrefab);
            }
        }
        headAnim.SetBool("shakeTime", shakeTime);
    }

    private void OnDisable()
    {
        lost = false;
    }

    bool HeadMaxed()
    {
        if(head.value < 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void HeadGrow()
    {
        if(HeadMaxed() != true)
        {
            head.value += headGain * Time.deltaTime;
        }
    }

    public void ClickHead()
    {
        if(head.value > .53)
        {
            head.value -= clickLoss;
            shakeTime = false;
            clicked = true;
            Debug.Log("Clicked");
            sr.color = oColor;
            tapSound.Play();
            glowReady = false;
            StopAllCoroutines();
            StartCoroutine("ClickWait");
        }
        if(strainPrefab != null)
        {
            Destroy(strainPrefab);
        }
    }

    IEnumerator ClickWait()
    {
        yield return new WaitForSeconds(clickWait);
        clicked = false;
    }

    void ShakeTime()
    {
        if(clicked == false)
        {
            if (head.value > shakeThresh)
            {
                shakeTime = true;
                StartCoroutine("ShellShock");
            }
        }
    }

    IEnumerator ShellShock()
    {
        while(shellAnim.speed < 1)
        {
            shellAnim.speed += .1f * Time.deltaTime;
            yield return null;
        }
    }

    void Glow()
    {
        if(head.value > .9)
        {
            if (glowReady == false)
            {
                glowReady = true;
                StartCoroutine("GlowUp");
            }
        } 
    }

    IEnumerator GlowUp()
    {
        strainPrefab = Instantiate(strain, null);
        while(sr.color.b > 0f && sr.color.g > 0f)
        {
            sr.color = new Color(sr.color.r, (sr.color.g - glowTime * Time.deltaTime), (sr.color.b - glowTime * Time.deltaTime), sr.color.a);
            yield return null;
        }
        lost = true;
        sr.color = Color.white;
        Debug.Log("Lost");
    }
}
