using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class MainMenuScript : MonoBehaviour {

    private LevelManager levelManager;//get handle on LevelManager object
    

    void Start()
    {
        levelManager = new LevelManager();// create new instance of level manager

    }

	public void PlayGame()
    {
        
        levelManager.ChangeLevel(Levels.Control_Settings);// change level when this method is triggered
    }

    public void Quit()
    {
        levelManager.QuitGame();// when the user clicks "QUIT"
    }
}
