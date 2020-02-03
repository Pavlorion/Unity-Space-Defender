﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endGame;

    private AudioSource music;


    // Use this for initialization
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            print("Duplicate music player self-desctructing");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.Play();
        }
    }

    void OnLevelWasLoaded(int level)
    {
        Debug.Log("Music Player: was loaded" + level);
        music.Stop();

        if (level == 0)
        {
            music.clip = startClip;
        }
        if (level == 1)
        {
            music.clip = gameClip;

        }
        if (level == 2)
        {
            music.clip = endGame;
        }
        music.Play();
    }

    void Update()
    {

    }

}
