using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    public GameObject flushIn;
    public AudioSource flushSound;

    Animator screenAnim;

    public GameObject theme;

    private void Awake()
    {
        screenAnim = GetComponent<Animator>();
    }

    public void StartGame()
    {
        theme.SetActive(false);
        flushIn.SetActive(true);
        flushSound.Play();
        screenAnim.SetTrigger("flush");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
