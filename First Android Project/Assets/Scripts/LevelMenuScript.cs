using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class LevelMenuScript : MonoBehaviour {

    

    private LevelManager levelManager;//get handle on LevelManager object

    void Start()
    {
        levelManager = new LevelManager();// create new instance of level manager
    }

    // Different Options
    public void Level1()
    {
        // SwitchScene("Level1");
        SwitchScene(Levels.Level_1);
    }

    public void Level2()
    {
        SwitchScene(Levels.Level_2);
    }

    public void Level3()
    {
        SwitchScene(Levels.Level_3);
    }

     public void Level4()
    {
        SwitchScene(Levels.Level_4);
    }

    public void Level5()
    {
        SwitchScene(Levels.Level_5);
    }

    public void Level6()
    {
        SwitchScene(Levels.Level_6);
    }

    public void redirect()
    {
        SwitchScene(Levels.Main_menu);
    }

    void SwitchScene(string sceneName) // Delegate the navigation of levels to its own method
    {
        levelManager.ChangeLevel(sceneName);// change level when this method is triggered
    }

   
}
