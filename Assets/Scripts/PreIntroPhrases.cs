using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreIntroPhrases : MonoBehaviour
{
    public AudioClip[] preIntroPhrases;
    public AudioClip[] introPhrases;

    public AudioSource phrasePlayer;

    public AudioSource stomachGroan;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayPreIntroPhrase()
    {
        StartCoroutine("Phrase");
    }
    IEnumerator Phrase()
    {
        Debug.Log("Playing");
        phrasePlayer.clip = preIntroPhrases[Random.Range(0, preIntroPhrases.Length)];
        phrasePlayer.Play();
        Debug.Log("Selected");
        while (phrasePlayer.isPlaying)
        {
            yield return null;
        }
        anim.speed = 0f;
        stomachGroan.Play();
        while (stomachGroan.isPlaying)
        {
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        phrasePlayer.clip = introPhrases[Random.Range(0, introPhrases.Length)];
        phrasePlayer.Play();
        while (phrasePlayer.isPlaying)
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
