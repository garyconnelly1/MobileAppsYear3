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
        if (Input.GetKeyDown(KeyCode.Escape)) // If the user presses the escape key while using a keyboard.
        {
            PauseGame(); // Trigger the pause game method.
        }

    }
    /* Adapted from: https://www.youtube.com/watch?v=JivuXdrIHK0 */
    public void PauseGame() // Method is triggered when the user presses the escape key or the pause UI button.
    {
            if (IsPaused) // If the game is already paused.
            {
                Resume(); // Resume the game.
            }
            else // If the game is not currently paused.
            {
                PauseMenu(); // Activate the pause menu.
            }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Dea-activate the pause menu.
        Time.timeScale = 1f; // Return the time scale to normal(1 second at a time).
        IsPaused = false; // Set the IsPaused variable back to false.
    }

    public void PauseMenu() // Whenever the pause menu is activated.
    {
        pauseMenuUI.SetActive(true); // Set the visibility of the panel to true.
        Time.timeScale = 0f; // Set the time scale to 0 so all the animations and timers appear to pause.
        IsPaused = true; // Set the isPaused variable to true while this menu is displayed.
    }

    public void MainMenu()
    {
        IsPaused = false; // Set the IsPaused variable to false so that is the user goes to main menu then exits the game, the level will start as normal next time around.
        pauseMenuUI.SetActive(false); // De-activate the pause menu.
        Time.timeScale = 1f; // Return the time scale to normal(1 second at a time).
        manager.ChangeLevel(Levels.Main_menu); // Use the level manager to change the view to the main menu.
    }

    public void Volume()
    {
        Debug.Log("Do something with sound");
    }
}
