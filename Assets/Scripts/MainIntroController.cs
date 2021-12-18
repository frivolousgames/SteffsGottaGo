using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainIntroController : MonoBehaviour
{

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Intro");
    }
}
