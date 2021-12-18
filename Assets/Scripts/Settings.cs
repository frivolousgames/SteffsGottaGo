using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer music;
    public AudioMixer sfx;
    public AudioMixer speech;

    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider speechSlider;

    private void Awake()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicSlider", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SfxSlider", 1f);
        speechSlider.value = PlayerPrefs.GetFloat("SpeechSlider", 1f);
    }

    private void Update()
    {

    }

    public void SetMusicSound()
    {
        float sliderValue = musicSlider.value;
        music.SetFloat("musicVol", Mathf.Log(sliderValue) * 20);

        PlayerPrefs.SetFloat("MusicSlider", sliderValue);

        PlayerPrefs.SetFloat("Music", Mathf.Log(sliderValue) * 20);
    }

    public void SetSfxSound()
    {
        float sliderValue = sfxSlider.value;
        sfx.SetFloat("sfxVol", Mathf.Log(sliderValue) * 20);

        PlayerPrefs.SetFloat("SfxSlider", sliderValue);

        PlayerPrefs.SetFloat("SFX", Mathf.Log(sliderValue) * 20);
    }

    public void SetSpeechSound()
    {
        float sliderValue = speechSlider.value;
        speech.SetFloat("speechVol", Mathf.Log(sliderValue) * 20);

        PlayerPrefs.SetFloat("SpeechSlider", sliderValue);

        PlayerPrefs.SetFloat("Speech", Mathf.Log(sliderValue) * 20);
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
