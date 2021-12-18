using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShartTankController : MonoBehaviour
{
    //Scene
    public void ExitScene()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
