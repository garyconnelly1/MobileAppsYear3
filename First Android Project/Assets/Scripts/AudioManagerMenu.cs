﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManagerMenu : MonoBehaviour { // This is  singleton audio manager so that audio can persist throughout multiplse scenes.

    public Sound[] sounds; // So that we can manage all of our audio files from this class.

    public static AudioManagerMenu instance;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) // Loop through each audio source and give it the following properties.
        {
            s.source = gameObject.AddComponent<AudioSource>(); // Add Audio source component.

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Menus"); // Anytime the audion manager is in a level, automatically play the main theme at the start of the level.
    }

    public void Play(string name)
    {
        Debug.Log("Play " + name);
        Sound s = Array.Find(sounds, sound => sound.name == name); // Call back function for finding the audio source in the array.
        if (s == null)
        {
            Debug.Log("Sound " + name + " does not exist");
            return;
        }
        s.source.Play(); // Play the audio.
    }
}
