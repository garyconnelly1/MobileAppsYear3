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
        Scene m_Scene = SceneManager.GetActiveScene(); // get a handle on the active scene
        sceneName = m_Scene.name; // get a handle on the active scene name
        Debug.Log("Inside skip");
    }
	
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Skip()
    {
         switch (sceneName)
         {
            case Levels.First_tutorial:
            
                 manager.ChangeLevel(Levels.First_level_tutorial);
                break;
            case Levels.First_level_tutorial:
                manager.ChangeLevel(Levels.Level_1);
                break;
            case Levels.Two_Three_tutorial:
                manager.ChangeLevel(Levels.Level_2);
                break;
            case Levels.Fourth_level_tutorial:
                manager.ChangeLevel(Levels.Level_4);
                break;
            case Levels.Fifth_level_tutorial:
                manager.ChangeLevel(Levels.Level_5);
                break;
            case Levels.Sixth_level_tutorial:
                manager.ChangeLevel(Levels.Level_6);
                break;
            default:
                 Debug.Log("Error in switch");
                break;
         }
 

       
    }
}
