using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class MainMenuScript : MonoBehaviour {

    private LevelManager levelManager; // Get handle on LevelManager object.
    

    void Start()
    {
        levelManager = new LevelManager();// Create new instance of level manager.

    }

	public void PlayGame()
    {
        
        levelManager.ChangeLevel(Levels.Control_Settings);// Change level when this method is triggered.
    }

    public void ShareButton()
    {
        levelManager.ChangeLevel(Levels.Share);// Change level when this method is triggered.
    }

    public void Quit()
    {
        levelManager.QuitGame();// When the user clicks "QUIT".
    }
}
