using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour {

    public static MenuSound Instance { get; private set; }

    AudioManager audioManager;
    

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audioManager = new AudioManager();
    }

    public void Play()
    {
        audioManager.Play("Menus"); 
    }
}
