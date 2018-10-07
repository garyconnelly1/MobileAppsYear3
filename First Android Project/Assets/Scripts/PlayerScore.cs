﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {
    private float timeLeft = 120f;
    public int score = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    private LevelManager levelManager;



    void Start()
    {
        levelManager = new LevelManager();
        DataManagement.dataManagement.loadData();// load the high score at the start of the game
    }

	
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = "Time Left " + (int)timeLeft;
        playerScoreUI.gameObject.GetComponent<Text>().text = "Score " + score;
        if (timeLeft < 0.1f)
        {
            levelManager.ChangeLevel("LevelsMenu");
        }
	}

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "EndLevel")
        {
            CountScore();
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
        Debug.Log("Current high score " + DataManagement.dataManagement.highScore);
        score = score + (int)(timeLeft * 10);
        DataManagement.dataManagement.highScore = score + (int)(timeLeft * 10); // save score
        DataManagement.dataManagement.saveData();// save the data
        Debug.Log("Current high score after saving " + DataManagement.dataManagement.highScore);      
    }
}
