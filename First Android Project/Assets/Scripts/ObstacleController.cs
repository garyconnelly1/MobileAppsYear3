using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    private float moveSpeed = -7f;

    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        levelManager = new LevelManager(); // Create new instance of level manager
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,
            transform.position.y); // Move the object accross the screen on the x axis.

        if (transform.position.x < -23f)
            Destroy(gameObject); // Destroy the game object off screen.

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "EndlessRunnerHamster") // If the object hits the player.
        {
            levelManager.ChangeLevel("LevelsMenu"); // Redirect back to level selection menu.
        }
    }
}
