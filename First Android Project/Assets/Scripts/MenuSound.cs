using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuSound : MonoBehaviour { // Singleton class that deals with the background audio playing for the menu views

    public static MenuSound Instance { get; private set; } // Getters and Setters.

    AudioManager audioManager;
    

    public void Awake()
    {
        if (Instance == null) // If there is no current instance
        {
            Instance = this; // Instance is this object
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); // Don't create an instance
        }
    }
    void Start()
    {
        audioManager = new AudioManager();
    }

    public void Play()
    {
        audioManager.Play("Menus"); // Playe the audion titled "Menus"
    
    }
}
