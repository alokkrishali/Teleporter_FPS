using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;
    public AudioClip[] MusicClipes;
    public AudioClip[] Sound;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    public void PlaySound(string SoundName)
    {
        switch(SoundName)
        {
            case "Menu":
                audioSource.clip = MusicClipes[0];
                break;
            case "GamePlay":
                audioSource.clip = MusicClipes[1];
                break;
        }
        audioSource.Play();
    }

    AudioClip oneShotSound;
    public void PlaySoundOnce(string SoundName)
    {
        switch (SoundName)
        {
            case "Die":
                oneShotSound = Sound[0];
                break;
            case "Killed":
                oneShotSound = Sound[1];
                break;
            case "GameOver":
                oneShotSound = Sound[2];
                break;
            case "GameComplete":
                oneShotSound = Sound[3];
                break;
        }
        audioSource.PlayOneShot(oneShotSound);
    }
}
