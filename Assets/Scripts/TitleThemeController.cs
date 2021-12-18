using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleThemeController : MonoBehaviour
{
    public AudioSource[] players;

    double player1Duration;
    double player2Duration;


    AudioSource currentPlayer;
    AudioSource nextPlayer;

    bool playSong;

    int plays = 0;

    double currentDuration;

    double currentTime;

    double nextStartTime;

    double dspTime;

    private void Awake()
    {
        playSong = true;
        //StartCoroutine("PlayThemeSequence");
    }

    private void Start()
    {
        player1Duration = (double)(players[0].clip.samples / players[0].clip.frequency) * 4;
        player2Duration = (double)(players[1].clip.samples / players[1].clip.frequency) * 2;

        currentDuration = player1Duration;
        currentPlayer = players[0];

        nextPlayer = players[1];
        nextStartTime = player1Duration;
    }

    private void Update()
    {
        dspTime = AudioSettings.dspTime;

        //nextPlayer.PlayScheduled()
    }

    IEnumerator PlayThemeSequence()
    {
        
        while(playSong == true)
        {
            SetPlayer();
            while (plays < 4)
            {
                currentPlayer.Play();
                while (currentPlayer.isPlaying)
                {
                    yield return null;
                }
                plays++;
            }
            yield return null;
        }
    }

    void SetPlayer()
    {
        if (currentPlayer == players[0])
        {
            nextPlayer = players[1];
            //plays = 2;
        }
        else
        {
            nextPlayer = players[0];
            //plays = 0;
        }
    }

}
