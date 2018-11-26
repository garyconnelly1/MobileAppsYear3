using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour { // The base class for handling all scene changes throughout the game.

    public void ChangeLevel(string level)
    {

        SceneManager.LoadScene(level); // Change scene.
    }

    public void QuitGame()
    {
        Application.Quit(); // Closes the application once this method is triggered.
    }

}
