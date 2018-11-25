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
        manager = new LevelManager();
    }

    public void Touch()
    {
        PlayerPrefs.SetString("Control", "Touch");
        manager.ChangeLevel(Levels.Level_menu);
    }

    public void KeyPad()
    {
        PlayerPrefs.SetString("Control", "Key");
        manager.ChangeLevel(Levels.Level_menu);
    }
}
