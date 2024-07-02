using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;


    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadVolume();
        }
        MusicVolume();
        SFXVolume();
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(_musicSlider.value);
        PlayerPrefs.SetFloat("musicVolume", _musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(_sfxSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", _sfxSlider.value);
    }

    private void LoadVolume()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        _sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }
}
