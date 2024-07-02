using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private bool confirm = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
           
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void UpdateMusic()
    {
        if (DecideMusic()!= musicSource.clip.name)
        {
            PlayMusic(DecideMusic());
        }  
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
    {
        confirm = false;
    }
    private void Update()
    {
        if (confirm == false)
        {
            UpdateMusic();
            confirm = true;
        }
    }
        private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("sfxVolume"))
        {
            AudioManager.instance.MusicVolume(PlayerPrefs.GetFloat("musicVolume"));
            AudioManager.instance.SFXVolume(PlayerPrefs.GetFloat("sfxVolume"));
        }
        else
        {
            Debug.Log("PlayerPrefs for sound not found");
            AudioManager.instance.MusicVolume(0.5f);
            AudioManager.instance.SFXVolume(0.5f);
        }
        PlayMusic(DecideMusic());
    }
    private string DecideMusic()
    {
        string chosenTheme = null;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case var n when n <= 2:
                chosenTheme = "Menu";
                break;
            case var n when (n>=3 && n<6):
                chosenTheme = "Forest";
                break;
            default:
                Debug.Log("Music for this build ID not found");
                break;
        }
        return chosenTheme;
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null) 
        {
            Debug.Log(s + "sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }

    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log(s + "sound not found");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }

    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
