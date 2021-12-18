using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
{
    public AudioSource soundPlayer_01;
    public AudioSource soundPlayer_02;
    public AudioSource motorSound;

    public AudioClip[] sounds;

    public float fastX;
    public float slowX;
    public float idleX;
    public float fadeX;

    //SPEECH
    public AudioSource phrasePlayer;

    public AudioClip[] phrases;

    //TalkSprite
    public GameObject talk;
    public GameObject player;

    //Player 1
    public void SoftHit()
    {
        soundPlayer_01.clip = sounds[0];
        soundPlayer_01.Play();
    }

    public void HardHit()
    {
        soundPlayer_01.clip = sounds[1];
        soundPlayer_01.Play();
    }

    public void GlassBreak()
    {
        soundPlayer_01.clip = sounds[2];
        soundPlayer_01.Play();
    }

    public void Shift()
    {
        soundPlayer_01.clip = sounds[3];
        soundPlayer_01.Play();
    }

    public void BackingBeeps()
    {
        soundPlayer_01.clip = sounds[4];
        soundPlayer_01.Play();
    }

    public void Creak()
    {
        soundPlayer_01.clip = sounds[5];
        soundPlayer_01.Play();
    }

    public void PapHitGround()
    {
        soundPlayer_01.clip = sounds[6];
        soundPlayer_01.Play();
    }

    public void Honk()
    {
        soundPlayer_01.clip = sounds[7];
        soundPlayer_01.Play();
    }

    public void DoorJam()
    {
        soundPlayer_01.clip = sounds[8];
        soundPlayer_01.Play();
    }

    public void Spill()
    {
        soundPlayer_01.clip = sounds[10];
        soundPlayer_01.Play();
    }

    //Player 2

    public void Slosh()
    {
        soundPlayer_02.clip = sounds[9];
        soundPlayer_02.Play();
    }

    //Motor
    public void MotorIdle()
    {
        StopCoroutine("CoFast");
        StopCoroutine("CoSlow");
        StartCoroutine("CoIdle");
    }

    IEnumerator CoIdle()
    {
        while (motorSound.pitch > 1f)
        {
            motorSound.pitch -= idleX * Time.deltaTime;
            yield return null;
        }
    }

    public void MotorFast()
    {
        StopCoroutine("CoIdle");
        StopCoroutine("CoSlow");
        StartCoroutine("CoFast");
    }

    IEnumerator CoFast()
    {
        while(motorSound.pitch < 2f)
        {
            motorSound.pitch += fastX * Time.deltaTime;
            yield return null;
        }
    }

    public void MotorSlow()
    {
        StopCoroutine("CoIdle");
        StopCoroutine("CoFast");
        StartCoroutine("CoSlow");
    }

    IEnumerator CoSlow()
    {
        while (motorSound.pitch < 1.3f)
        {
            motorSound.pitch += slowX * Time.deltaTime;
            yield return null;
        }
    }

    public void FadeMotor()
    {
        StartCoroutine("CoFade");
    }

    IEnumerator CoFade()
    {
        while (motorSound.volume > 0f)
        {
            motorSound.volume -= fadeX * Time.deltaTime;
            yield return null;
        }
    }

    public void MotorRise()
    {
        StartCoroutine("CoRise");
    }

    IEnumerator CoRise()
    {
        while (motorSound.volume > 0f)
        {
            motorSound.pitch += slowX * Time.deltaTime;
            yield return null;
        }
    }

    //SPEECH

    public void ThankGod()
    {
        phrasePlayer.clip = phrases[0];
        phrasePlayer.Play();
    }

    public void Turtlehead()
    {
        phrasePlayer.clip = phrases[1];
        phrasePlayer.Play();
    }

    public void Occupado()
    {
        phrasePlayer.clip = phrases[2];
        phrasePlayer.Play();
    }

    public void Jerk()
    {
        phrasePlayer.clip = phrases[3];
        phrasePlayer.Play();
    }

    public void Heck()
    {
        phrasePlayer.clip = phrases[4];
        phrasePlayer.Play();
    }

    public void NotFunny()
    {
        phrasePlayer.clip = phrases[5];
        phrasePlayer.Play();
    }

    public void OhGeez()
    {
        phrasePlayer.clip = phrases[6];
        phrasePlayer.Play();
    }

    public void OuttaHere()
    {
        phrasePlayer.clip = phrases[7];
        phrasePlayer.Play();
    }

    public void DoorJammed()
    {
        phrasePlayer.clip = phrases[8];
        phrasePlayer.Play();
    }

    public void GoinOn()
    {
        phrasePlayer.clip = phrases[9];
        phrasePlayer.Play();
    }

    public void OMG()
    {
        phrasePlayer.clip = phrases[10];
        phrasePlayer.Play();
    }

    public void OMGDark()
    {
        phrasePlayer.clip = phrases[11];
        phrasePlayer.Play();
    }

    public void Crap()
    {
        phrasePlayer.clip = phrases[12];
        phrasePlayer.Play();
    }

    public void StopPhrase()
    {
        phrasePlayer.Stop();
    }

    //Talk

    public void Talk()
    {
        StartCoroutine("CoTalk");
    }

    IEnumerator CoTalk()
    {
        player.SetActive(false);
        talk.SetActive(true);
        while (phrasePlayer.isPlaying)
        {
            Debug.Log("Playing");
            yield return null;
        }
        player.SetActive(true);
        talk.SetActive(false);
    }

    //End

    public void LoadLevel()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
