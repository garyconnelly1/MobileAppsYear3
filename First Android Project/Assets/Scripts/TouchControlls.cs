using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class TouchControlls : MonoBehaviour { // Simple class to manage how the user wants to control the player

    public static TouchControlls Instance { get; private set; }

    LevelManager manager;

    public static bool isTouch = false;

   

    void Start()
    {
        manager = new LevelManager(); // Initialize the Level Manager.
    }

    public void Touch() // If the user wants touch controls.
    {
        PlayerPrefs.SetString("Control", "Touch"); // Set the "Control" prefab to "Touch".
        manager.ChangeLevel(Levels.Level_menu); // Redirect to the levels menu.
    }

    public void KeyPad()
    {
        PlayerPrefs.SetString("Control", "Key"); // Set the "Control" prefab to "Key" for keyboard controls.
        manager.ChangeLevel(Levels.Level_menu); // Redirect to the levels menu.
    }

    public void MainMenu()
    {
        manager.ChangeLevel(Levels.Main_menu); // An option to be redirected back to the main menu.
    }
}
