using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
CITATION: Some of the following code was adapted from this tutorial: https://www.youtube.com/watch?v=DU7cgVsU2rM
*/

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private GameObject volumeMenu;

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("MasterVolume", level);
    }

    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("SoundFXVolume", level);
    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("MusicVolume", level);
    }

    public void ToggleVolumeMenu()
    {
        volumeMenu.SetActive(!volumeMenu.activeSelf);
    }
}
