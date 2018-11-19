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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

    }

    public void PauseGame()
    {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                PauseMenu();
            }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void PauseMenu()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void MainMenu()
    {
        IsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        manager.ChangeLevel(Levels.Main_menu);
    }

    public void Volume()
    {
        Debug.Log("Do something with sound");
    }
}
