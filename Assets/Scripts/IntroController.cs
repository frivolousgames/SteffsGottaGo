using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public AudioClip[] introPhrases;
    public AudioSource introPhrasePlayer;
    public AudioSource whistle;
    public AudioSource stomachGroan;

    public GameObject skip;

    private void Awake()
    {
        
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("HowToPlay", 0) == 0)
        {
            skip.SetActive(false);
        }
    }

    public void StomachGroan()
    {
        //whistle.Stop();
        stomachGroan.Play();
        StartCoroutine("Phrase");
    }
    IEnumerator Phrase()
    {
        while (stomachGroan.isPlaying)
        {
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        if (PlayerPrefs.GetInt("HowToPlay", 0) == 0)
        {
            introPhrasePlayer.clip = introPhrases[4];
        }
        else
        {
            introPhrasePlayer.clip = introPhrases[Random.Range(0, introPhrases.Length)];
        }
        
        introPhrasePlayer.Play();
        while (introPhrasePlayer.isPlaying)
        {
            yield return null;
        }
        // yield return new WaitForSeconds(.25f); 
        if (PlayerPrefs.GetInt("HowToPlay", 0) == 0)
        {
            SceneManager.LoadSceneAsync("HowToPlay");
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }
    public void Skip()
    {
        if (PlayerPrefs.GetInt("HowToPlay", 0) == 0)
        {
            SceneManager.LoadSceneAsync("HowToPlay");
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }
}
