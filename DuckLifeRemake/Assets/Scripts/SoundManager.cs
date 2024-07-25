using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
CITATION: Some of the following code was adapted from this tutorial: https://www.youtube.com/watch?v=DU7cgVsU2rM
*/

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;    // singleton reference
    [SerializeField] private AudioSource soundObject;

    private void Awake()
    {
        if(instance == null)    // if there is no assigned singleton
        {
            instance = this;    // assign this object as the singleton
        }
    }

    public void PlaySoundClip(AudioClip clip, float volume)
    {
        // spawn gameObject
        AudioSource audioSource = Instantiate(soundObject);

        // assign the audio clip to the audio source
        audioSource.clip = clip;

        // assign volume
        audioSource.volume = volume;

        // play audio clip
        audioSource.Play();

        // get length of audio clip
        float clipLength = audioSource.clip.length;

        // destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);
    }
}
