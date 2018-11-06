using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {
    private float timeLeft = 120f;
    public int score = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    public GameObject highScore;
    private LevelManager levelManager;



    void Start()
    {
        Scene m_Scene = SceneManager.GetActiveScene();
        string sceneName = m_Scene.name;
        levelManager = new LevelManager();
        DataManagement.dataManagement.loadData();// load the high score at the start of the game
        highScore.gameObject.GetComponent<Text>().text = "High Score " + HighScoreCalculation.getHighScore(sceneName);
    }

	
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = "Time Left " + (int)timeLeft;
        playerScoreUI.gameObject.GetComponent<Text>().text = "Score " + score;
        if (timeLeft < 0.1f)
        {
            Player_move.facingRight = false;
            levelManager.ChangeLevel("LevelsMenu");
        }
	}

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "EndLevel")
        {
            CountScore();
            CountScorePlayerPrefs();
            levelManager.ChangeLevel("LevelsMenu");// load new level of the game
            Debug.Log("New scene");
           
        }

        if (trig.gameObject.tag == "Coin")
        {
            score += 10;
            Destroy(trig.gameObject);
        }

    }

    void CountScore()
    {
      //  Debug.Log("Current high score " + DataManagement.dataManagement.highScore);
        score = score + (int)(timeLeft * 10);
        DataManagement.dataManagement.highScore = score + (int)(timeLeft * 10); // save score
        DataManagement.dataManagement.saveData();// save the data
       // Debug.Log("Current high score after saving " + DataManagement.dataManagement.highScore);      
    }


    void CountScorePlayerPrefs()
    {
        score = score + (int)(timeLeft * 10);
        //Debug.Log("Player prefs score = " + score);

        Scene m_Scene = SceneManager.GetActiveScene();
        string sceneName = m_Scene.name;

        // Debug.Log("///////////////////////////////" + sceneName);
        int highScore = HighScoreCalculation.getHighScore(sceneName);
        if (score > highScore)
        {
            HighScoreCalculation.setHighScore(sceneName, score);
        }

        Debug.Log("The high score for " + sceneName + " is " + HighScoreCalculation.getHighScore(sceneName));
    }

}
