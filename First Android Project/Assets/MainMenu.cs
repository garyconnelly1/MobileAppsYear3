using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    private LevelManager levelManager;

    public void PlayGame()
    {
        levelManager = new LevelManager();
        levelManager.ChangeLevel("sideScroller1");
    }

}
