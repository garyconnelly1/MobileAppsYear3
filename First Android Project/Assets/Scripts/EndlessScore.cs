﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessScore : MonoBehaviour {

    public GameObject playerScoreUI;
    public GameObject highScoreUI;
    private int time = 0;
    private int score;
    Scene m_Scene;
    private string sceneName;

    // Use this for initialization
    void Start () {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name; // Get a handle on the current scene name.
        highScoreUI.gameObject.GetComponent<Text>().text = "High Score " + HighScoreCalculation.getHighScore(sceneName); // Retrieve the high socre for this level from the HighScoreCalculator.

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        time++;
        if (time % 100 == 0) // Every 100 frames, add 1 to the current score.
        {
            score++;
        }
        sceneName = m_Scene.name; // Get a handle on the current level.
        playerScoreUI.gameObject.GetComponent<Text>().text = "Score " + score; // Update the score UI element.
        int highScore = HighScoreCalculation.getHighScore(sceneName); // Get a handle on the current high score.

        if (score > highScore) // If the current score is bigger than the high score,
        {
            HighScoreCalculation.setHighScore(sceneName, score); // Override the high score with the current score.
        }

    }
}
