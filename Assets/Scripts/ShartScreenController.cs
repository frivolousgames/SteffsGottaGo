using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShartScreenController : MonoBehaviour
{
    Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Play()
    {
        anim.SetTrigger("Play");
    }

    public void LoadTank()
    {
        SceneManager.LoadScene("ShartTank");
    }
}
