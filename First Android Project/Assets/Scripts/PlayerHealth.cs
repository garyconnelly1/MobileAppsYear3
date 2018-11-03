using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int deathPoint;
    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        levelManager = new LevelManager();// create new instance of level manager
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y < deathPoint)
        {
            Die(); // kill the player when it falls below a certain point on the y axis
            Player_move.facingRight = false; // reset the direction the player is facing when it dies
        }

       
	}

    void Die()
    {
        levelManager.ChangeLevel("LevelsMenu");// redirect the user to the level selection menu when player dies
    }
}
