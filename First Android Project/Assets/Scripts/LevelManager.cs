using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void ChangeLevel(string level)
    {

        SceneManager.LoadScene(level);//change level
    }

    public void QuitGame()
    {
        Application.Quit();//closes the application once this method is triggered
        Debug.Log("Quitting game");

    }

}
