using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound  { // base class for sound objects

    public string name; // each sound needs a name

    public AudioClip clip; // each sound has an audio clip

    [Range(0f, 1f)]
    public float volume; // give each sound a range for column

    [Range(0.1f,3)]
    public float pitch; // give each sound a pitch

    [HideInInspector]
    public AudioSource source; // give each sound an audio source

    public bool loop; // set whether or not the sound will loop
}
