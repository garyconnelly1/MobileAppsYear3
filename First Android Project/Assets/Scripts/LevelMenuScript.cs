using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class LevelMenuScript : MonoBehaviour { // Class that controlls the Level menu scene.

    

    private LevelManager levelManager; // Get handle on LevelManager object.

    void Start()
    {
        levelManager = new LevelManager();// Create new instance of level manager.
    }

    // Different Options
    public void Level1()
    {
        SwitchScene(Levels.First_tutorial);
    }

    public void Level2()
    {
        SwitchScene(Levels.Two_Three_tutorial);
    }

    public void Level3()
    {
        SwitchScene(Levels.Level_3);
    }

     public void Level4()
    {
        SwitchScene(Levels.Fourth_level_tutorial);
    }

    public void Level5()
    {
        SwitchScene(Levels.Fifth_level_tutorial);
    }

    public void Level6()
    {
        SwitchScene(Levels.Sixth_level_tutorial);
    }

    public void redirect()
    {
        SwitchScene(Levels.Main_menu);
    }

    void SwitchScene(string sceneName) // Delegate the navigation of levels to its own method.
    {
        levelManager.ChangeLevel(sceneName);// Change scene when this method is triggered.
    }

   
}
