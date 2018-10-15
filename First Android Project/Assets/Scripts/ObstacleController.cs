using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public float moveSpeed = -5f;

    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        levelManager = new LevelManager(); // create new instance of level manager
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,
            transform.position.y); // move the object accross the screen on the x axis

        if (transform.position.x < -23f)
            Destroy(gameObject); // destroy the game object off screen 

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "EndlessRunnerHamster") // if the object hits the player
        {
            levelManager.ChangeLevel("LevelsMenu"); // redirect back to level selection menu
        }
    }
}
