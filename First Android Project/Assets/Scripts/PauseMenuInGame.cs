using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PauseMenuInGame : MonoBehaviour {

    public static bool IsPaused = false;
    public GameObject pauseMenuUI;
    private LevelManager manager = new LevelManager();
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) // if the user presses the escape key while using a keyboard.
        {
            PauseGame(); // trigger the pause game method.
        }

    }
    /* Adapted from: https://www.youtube.com/watch?v=JivuXdrIHK0 */
    public void PauseGame() // method is triggered when the user presses the escape key or the pause UI button.
    {
            if (IsPaused) // If the game is already paused.
            {
                Resume(); // resume the game.
            }
            else // if the game is not currently paused.
            {
                PauseMenu(); // activate the pause menu.
            }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // dea-activate the pause menu.
        Time.timeScale = 1f; // return the time scale to normal(1 second at a time).
        IsPaused = false; // set the IsPaused variable back to false.
    }

    public void PauseMenu() // whenever the pause menu is activated.
    {
        pauseMenuUI.SetActive(true); // set the visibility of the panel to true.
        Time.timeScale = 0f; // set the time scale to 0 so all the animations and timers appear to pause.
        IsPaused = true; // set the isPaused variable to true while this menu is displayed.
    }

    public void MainMenu()
    {
        IsPaused = false; // set the IsPaused variable to false so that is the user goes to main menu then exits the game, the level will start as normal next time around.
        pauseMenuUI.SetActive(false); // de-activate the pause menu.
        Time.timeScale = 1f; // return the time scale to normal(1 second at a time).
        manager.ChangeLevel(Levels.Main_menu); // use the level manager to change the view to the main menu.
    }

    public void Volume()
    {
        Debug.Log("Do something with sound");
    }
}
