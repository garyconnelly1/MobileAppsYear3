using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
/* Adapted from https://www.youtube.com/watch?v=6OT43pvUyfY&t=693s */
public class AudioManager : MonoBehaviour {

    public Sound[] sounds; // so that we can manage all of our audio files from this class
    public bool isMuted = false;
    public string sourceName;

	// Use this for initialization
	void Awake () {
        foreach (Sound s in sounds) // loop through each audio source and give it the following properties
        {
            s.source = gameObject.AddComponent<AudioSource>(); // add Audio source component

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    void Start()
    {
        sourceName = "MainTheme";
        Play(sourceName); // anytime the audion manager is in a level, automatically play the main theme at the start of the level
    }
	
	public void Play(string name)
    {
        Debug.Log("Play " + name);
        Sound s = Array.Find(sounds, sound => sound.name == name); // call back function for finding the audio source in the array
        if (s == null)
        {
            Debug.Log("Sound " + name + " does not exist");
            return;
        }
        s.source.Play(); // play the audio
       
       
    }

    public void Mute() // for when the player selects "mute in the pause menu as per design document"
    {

        Debug.Log("mute " + sourceName);
        Sound s = Array.Find(sounds, sound => sound.name == sourceName); // call back function for finding the audio source in the array
        if (s == null)
        {
            Debug.Log("Sound " + name + " does not exist");
            return;
        }
        s.source.mute = !s.source.mute;

    }
}
