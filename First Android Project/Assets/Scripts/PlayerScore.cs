using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts;

public class PlayerScore : MonoBehaviour {
    private float timeLeft = 120f;
    public int score = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    public GameObject highScore;
    private LevelManager levelManager;
    string sceneName;



    void Start()
    {
        Scene m_Scene = SceneManager.GetActiveScene(); // get a handle on the active scene
        sceneName = m_Scene.name; // get a handle on the active scene name
        levelManager = new LevelManager(); // get a new instaqnce of the level manager object
        DataManagement.dataManagement.loadData();// load the high score at the start of the game
        highScore.gameObject.GetComponent<Text>().text = "High Score " + HighScoreCalculation.getHighScore(sceneName); // load the highscore from the player prefs
    }

	
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = "Time Left " + (int)timeLeft;
        playerScoreUI.gameObject.GetComponent<Text>().text = "Score " + score;
        if (timeLeft < 0.1f) // if the time runs out
        {
            Player_move.facingRight = false; // reset the direction the player is facing
            levelManager.ChangeLevel(Levels.Level_menu); // redirect to the LevelsMenu
        }
	}

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "EndLevel") // once the player reaches the end of the level
        {
            CountScore();
            CountScorePlayerPrefs(); // count the score
            if (sceneName == Levels.Level_5)
            {
                levelManager.ChangeLevel(Levels.Winner_Screen);// load winner screen 
            }
            else
            {
                levelManager.ChangeLevel(Levels.Level_menu);// load new level of the game 
            }
            
        }

        if (trig.gameObject.tag == "Coin") // if the player hits a seed
        {
            score += 10; // increase the player score by 10
            Destroy(trig.gameObject); // and destroy the seed to give the illusion that the hamster consumed it
        }

    }

    void CountScore()
    {
        score = score + (int)(timeLeft * 10);
        DataManagement.dataManagement.highScore = score + (int)(timeLeft * 10); // save score
        DataManagement.dataManagement.saveData();// save the data    
    }


    void CountScorePlayerPrefs() // my preffered way of saving data
    {
        score = score + (int)(timeLeft * 10); // calculate the current score with this formula
       
        Scene m_Scene = SceneManager.GetActiveScene(); // get a handle on the active scene
        string sceneName = m_Scene.name; // get a handle on the active scenes name

        int highScore = HighScoreCalculation.getHighScore(sceneName);// get a handle on the high socre for the active scene
        if (score > highScore) // if the current score is higher than the highscore
        {
            HighScoreCalculation.setHighScore(sceneName, score); // override the high score with the current score
        }
    }

}
