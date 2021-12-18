using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioController : MonoBehaviour
{
    //Main Players
    public AudioSource speechPlayer;
    public AudioClip[] speechClips;

    public AudioClip[] winPhrases;
    public UnityEvent winPhraseOver;

    public AudioClip[] losePhrases;
    public UnityEvent losePhraseOver;
    public UnityEvent lost;

    public AudioSource playerSoundPlayer;
    public AudioClip[] playerSounds;
    public static int psIndex;

    public AudioSource obstaclePlayer;
    public AudioClip[] obstacleSounds;

    public AudioSource sfxPlayer;
    public AudioClip[] sfxClips;
    public static int sfxIndex;

    //Extra Clips

    public AudioSource toiletFlush;

    public void PlayWinPhrase()
    {
        StartCoroutine(WinPhrase());
    }

    

    IEnumerator WinPhrase()
    {
        yield return new WaitForSeconds(1.3f);
        sfxPlayer.clip = sfxClips[1];
        sfxPlayer.Play();
        while (sfxPlayer.isPlaying)
        {
            yield return null;
        }
        yield return new WaitForSeconds(.1f);
        speechPlayer.clip = winPhrases[Random.Range(0, winPhrases.Length)];
        speechPlayer.Play();
        while (speechPlayer.isPlaying)
        {
            yield return null;
        }
        yield return new WaitForSeconds(.3f);
        winPhraseOver.Invoke();
    }

    public void PlayLosePhrase()
    {
        StartCoroutine(LosePhrase());
    }

    IEnumerator LosePhrase()
    {
        yield return new WaitForSeconds(.5f);
        sfxPlayer.clip = sfxClips[5];
        sfxPlayer.Play();
        lost.Invoke();
        while (sfxPlayer.isPlaying)
        {
            yield return null;
        }
        yield return new WaitForSeconds(.3f);
        speechPlayer.clip = losePhrases[Random.Range(0, losePhrases.Length)];
        speechPlayer.Play();
        
        while (speechPlayer.isPlaying)
        {
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        losePhraseOver.Invoke();
    }

    public void DoorSlamSound()
    {
        StartCoroutine("DoorSlam");
    }

    IEnumerator DoorSlam()
    {
        yield return new WaitForSeconds(.1f);
        SfxPlay(0);
    }

    public void ToiletFlush()
    {
        toiletFlush.Play();
    }

    public void SfxPlay(int index)
    {
        sfxPlayer.clip = sfxClips[index];
        sfxPlayer.Play();
    }

    public void PlayerSound(int index)
    {
        playerSoundPlayer.clip = playerSounds[index];
        playerSoundPlayer.Play();
    }
}
