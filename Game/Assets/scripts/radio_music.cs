using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class Radio_Musc : MonoBehaviour
{

    public AudioClip[] musicClips;
    private int currentTrack;
    private int isItOn;
    private AudioSource source;

    public Material powerOnMaterial;
    public Material powerOffMaterial;
    Renderer rend;

    void Start()
    {
        source = GetComponent<AudioSource>();

        //source.mute = true;
    }

    public void PlayMusic()
    {
        isItOn = 1;
        if (source.isPlaying) { return; }

        currentTrack--;

        if (currentTrack < 0)
        {
            currentTrack = musicClips.Length - 1;
        }
        StartCoroutine(WaitForMusicEnd());
    }

    IEnumerator WaitForMusicEnd()
    {
        while (source.isPlaying) { yield return null; }
        NextTrack();
    }

    public void NextTrack()
    {
        if (isItOn == 1)
        {
            source.Stop();
            currentTrack++;

            if (currentTrack > musicClips.Length - 1) { currentTrack = 0; }

            source.clip = musicClips[currentTrack];
            source.Play();

            StartCoroutine(WaitForMusicEnd());
        }
    }

    public void StopMusic()
    { 
        StopCoroutine(WaitForMusicEnd());
        StopAllCoroutines();
        source.Stop();
        isItOn = 0;
    }

    public void Power()
    {
        if (isItOn == 0)
        {
            rend = GetComponent<Renderer>(); // Добавить эту строку для получения рендерера
            if (rend != null) // Проверить, что рендерер существует
            {
                rend.material = powerOnMaterial;
            }
            PlayMusic();
        }
        else if (isItOn == 1)
        {
            rend = GetComponent<Renderer>(); // Добавить эту строку для получения рендерера
            if (rend != null) // Проверить, что рендерер существует
            {
                rend.material = powerOffMaterial;
            }
            StopMusic();
        }
    }

}
