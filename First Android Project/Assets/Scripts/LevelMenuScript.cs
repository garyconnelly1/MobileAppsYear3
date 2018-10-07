using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuScript : MonoBehaviour {

    

    private LevelManager levelManager;//get handle on LevelManager object

    void Start()
    {
        levelManager = new LevelManager();// create new instance of level manager
    }

    // Different Options
    public void Level1()
    {
        SwitchScene("Level1");
    }

    public void Level2()
    {
        SwitchScene("Level2");
    }

    public void Level3()
    {
        SwitchScene("Level3");
    }

     public void Level4()
    {
        SwitchScene("Level4");
    }

    public void Level5()
    {
        SwitchScene("Level5");
    }

    public void Level6()
    {
        SwitchScene("Level6");
    }

    public void redirect()
    {
        SwitchScene("MainMenu");
    }

    void SwitchScene(string sceneName) // Delegate the navigation of levels to its own method
    {
        levelManager.ChangeLevel(sceneName);// change level when this method is triggered
    }

   
}
