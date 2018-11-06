using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreCalculation : MonoBehaviour {
    private static int PlayerHighScore;

	// Use this for initialization
	void Start () {
		
	}

    public static int getHighScore(string level)
    {
        return PlayerPrefs.GetInt(level);
    }
	
	public static void setHighScore(string level, int score)
    {
        PlayerPrefs.SetInt(level, score);
    }
}
