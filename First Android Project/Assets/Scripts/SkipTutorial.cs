using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class SkipTutorial : MonoBehaviour {

    LevelManager manager = new LevelManager();
    private string sceneName;

    void Start()
    {
        Scene m_Scene = SceneManager.GetActiveScene(); // Get a handle on the active scene.
        sceneName = m_Scene.name; // Get a handle on the active scenes name.
    }
	
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Skip()
    {
         switch (sceneName) // Switch statement on the tutorial scenes to determine what level to skip to.
         {
            case Levels.First_tutorial:  // For the opening tutorial>
            
                 manager.ChangeLevel(Levels.First_level_tutorial); // Go to tutorial for level 1.
                break;
            case Levels.First_level_tutorial: // For the first tutorial>
                manager.ChangeLevel(Levels.Level_1); // Go to level 1.
                break;
            case Levels.Two_Three_tutorial: // For the tutorial for the 2nd and 3rd levels> 
                manager.ChangeLevel(Levels.Level_2); // Just skip to level 2.
                break;
            case Levels.Fourth_level_tutorial: // For the fourth tutorial>
                manager.ChangeLevel(Levels.Level_4); // Skip to level 4.
                break;
            case Levels.Fifth_level_tutorial: // For the fifth tutorial>
                manager.ChangeLevel(Levels.Level_5); // Skip to level 5.
                break;
            case Levels.Sixth_level_tutorial: // For the last tutorial>
                manager.ChangeLevel(Levels.Level_6); // Skip to level 6.
                break;
            case Levels.Winner_Screen: // For the Winner screen>
                manager.ChangeLevel(Levels.Level_6); // Skip to level 6.
                break;
            default:
                 Debug.Log("Error in switch");
                break;
         }
 

       
    }
}
