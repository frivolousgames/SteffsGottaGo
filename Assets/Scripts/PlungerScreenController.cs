using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlungerScreenController : MonoBehaviour
{
    public GameObject[] plungers;

    public GameObject next, retry, exit;

    Animator anim;

    public AudioSource plungerSound;

    public AudioSource yaySound;

    string[] intros;
    string selectedIntro;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        intros = new string[] { "Intro", "Intro 2", "Intro 3" };
        selectedIntro = intros[Random.Range(0, intros.Length)];
    }

    private void OnEnable()
    {
        plungerSound.pitch = .5f;
        
    }

    public void ActivatePlungers()
    {
        StartCoroutine("PlungerActivator");
    }

    public IEnumerator PlungerActivator()
    {
        for(int i = 0; i < MainSceneController.plungerAmount; i++)
        {
            yield return new WaitForSeconds(.5f);
            plungers[i].SetActive(true);
            plungerSound.pitch += .25f;
            plungerSound.Play();
        }
        yield return new WaitForSeconds(.05f);
        if(MainSceneController.plungerAmount == 3)
        {
            yaySound.Play();
        }
        yield return new WaitForSeconds(.45f);
        if (MainSceneController.plungerAmount < 2 || PlayerPrefs.GetInt("Level", 0) > MainSceneController.levelObstaclesLength - 2) 
        {
            next.GetComponent<Button>().interactable = false;
        }
        anim.SetTrigger("slide");
    }

    public void Next()
    {
        //SceneManager.LoadScene("Intro");
    }

    public void Retry()
    {
        SceneManager.LoadScene(selectedIntro);
    }

    public void Quit()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
