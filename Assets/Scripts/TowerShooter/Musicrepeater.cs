using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XR;

public class Musicrepeater : MonoBehaviour
{   
    

    [Header("music")] 
    public AudioClip[] music = new AudioClip[16];

    private AudioSource _audioSource;
    
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = music[0];
        _audioSource.Play();
        
        GameManager.LevelChanged += SetSoundIndex;
        GameManager.GameStateChanged += GameStateChanged;
    }

    // Update is called once per frame
    void SetSoundIndex(int index)
    {
        _audioSource.clip = music[Math.Clamp(index, 0, music.Length - 1)];
    }

    void GameStateChanged(GameState newState)
    {
        if (newState.IsPlaying())
        {
            _audioSource.UnPause();
        }else{
            _audioSource.Pause();
        }
    }
}
