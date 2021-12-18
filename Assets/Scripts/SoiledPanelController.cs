using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoiledPanelController : MonoBehaviour
{
    string[] intros;
    string selectedIntro;

    public GameObject extraScreen;

    private void Awake()
    {
        intros = new string[] { "Intro", "Intro 2", "Intro 3" };
        selectedIntro = intros[Random.Range(0, intros.Length)];
        StartCoroutine("ExtraActive");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(selectedIntro);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    IEnumerator ExtraActive()
    {
        yield return new WaitForSeconds(1f);
        extraScreen.SetActive(true);
    }
}
