using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuScript : MonoBehaviour {

    

    private LevelManager levelManager;//get handle on LevelManager object

    void Start()
    {
        levelManager = new LevelManager();// create new instance of level manager
    }

    public void Level1()
    {
        SwitchScene("Level1");
    }

    public void Level2()
    {
        SwitchScene("Level2");
    }

    void SwitchScene(string sceneName) // Delegate the navigation of levels to its own method
    {
        levelManager.ChangeLevel(sceneName);// change level when this method is triggered
    }

   
}
