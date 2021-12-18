using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetAudio : MonoBehaviour
{
    public AudioMixer music;
    public AudioMixer sfx;
    public AudioMixer speech;

    private void Start()
    {
        float musicLevel = PlayerPrefs.GetFloat("Music", 0);
        SetMusicLevel(musicLevel);

        float sfxLevel = PlayerPrefs.GetFloat("SFX", 0);
        SetSfxLevel(sfxLevel);

        float speechLevel = PlayerPrefs.GetFloat("Speech", 0);
        SetSpeechLevel(speechLevel);
    }

    public void SetMusicLevel(float musicLevel)
    {
        music.SetFloat("musicVol", musicLevel);
    }

    public void SetSfxLevel(float sfxLevel)
    {
        sfx.SetFloat("sfxVol", sfxLevel);
    }

    public void SetSpeechLevel(float speechLevel)
    {
        speech.SetFloat("speechVol", speechLevel);
    }
}
