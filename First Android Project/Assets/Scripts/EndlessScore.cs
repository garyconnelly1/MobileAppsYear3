using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessScore : MonoBehaviour {

    public GameObject playerScoreUI;
    public GameObject highScoreUI;
    private int time = 0;
    private int score;
    Scene m_Scene = SceneManager.GetActiveScene();
    private string sceneName;

    // Use this for initialization
    void Start () {

        sceneName = m_Scene.name; // get a handle on the current scene name
        highScoreUI.gameObject.GetComponent<Text>().text = "High Score " + HighScoreCalculation.getHighScore(sceneName); // retrieve the high socre for this level from the HighScoreCalculator

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        time++;
        if (time % 100 == 0) // every 100 frames, add 1 to the current score
        {
            score++;
        }
        sceneName = m_Scene.name; // get a handle on the current level
        playerScoreUI.gameObject.GetComponent<Text>().text = "Score " + score; // update the score UI element
        int highScore = HighScoreCalculation.getHighScore(sceneName); // get a handle on the current high score

        if (score > highScore) // if the current score is bigger than the high score,
        {
            HighScoreCalculation.setHighScore(sceneName, score); // override the high score with the current score
        }

    }
}
