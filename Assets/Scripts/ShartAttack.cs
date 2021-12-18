using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Audio;

public class ShartAttack : MonoBehaviour
{
    public AudioClip[] shartPhrase;
    public AudioClip imOut;
    public Sprite[] shartArt;
    public AudioSource shartPhrasePlayer;


    AudioClip selectedClip;
    Sprite selectedShartArt;

    public Image shartImage;

    int lastShart;

    public UnityEvent phraseOver;

    public AudioMixer speech;

    private void OnEnable()
    {
        lastShart = PlayerPrefs.GetInt("LastShart", 0);
        SetShartArt();
        SetShartAudio();
    }

    void SetShartArt()
    {
        if (lastShart == 0)
        {
            selectedShartArt = shartArt[1];
            PlayerPrefs.SetInt("LastShart", 1);
        }
        else
        {
            selectedShartArt = shartArt[0];
            PlayerPrefs.SetInt("LastShart", 0);
        }
        shartImage.sprite = selectedShartArt;
    }
    void SetShartAudio()
    {
        selectedClip = shartPhrase[Random.Range(0, shartPhrase.Length)];
        shartPhrasePlayer.clip = selectedClip;
        if(lastShart == 1)
        {
            shartPhrasePlayer.pitch = 1.2f;
            //speech.SetFloat("pitch", 1.2f);
        }
        else
        {
            shartPhrasePlayer.pitch = 1f;
            //speech.SetFloat("pitch", 1f);
        }
    }

    public IEnumerator PlayPhrase()
    {
        shartPhrasePlayer.Play();
        while (shartPhrasePlayer.isPlaying)
        {
            yield return null;
        }
        shartPhrasePlayer.clip = imOut;
        yield return new WaitForSeconds(.4f);
        shartPhrasePlayer.Play();
        yield return new WaitForSeconds(2.4f);
        phraseOver.Invoke();
    }

    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
