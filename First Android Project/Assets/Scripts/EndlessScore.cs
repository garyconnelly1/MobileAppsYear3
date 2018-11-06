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

        sceneName = m_Scene.name;
        highScoreUI.gameObject.GetComponent<Text>().text = "High Score " + HighScoreCalculation.getHighScore(sceneName);

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        time++;
        if (time % 100 == 0)
        {
            score++;
        }
        sceneName = m_Scene.name;
        playerScoreUI.gameObject.GetComponent<Text>().text = "Score " + score;
        int highScore = HighScoreCalculation.getHighScore(sceneName);

        if (score > highScore)
        {
            HighScoreCalculation.setHighScore(sceneName, score);
        }

    }
}
