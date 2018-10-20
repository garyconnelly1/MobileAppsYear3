using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    public int bossSpeed;
    public float xMax;
    public float xMin;
    private bool isRight;
    private LevelManager levelManager;//get handle on LevelManager object

    // Use this for initialization
    void Start () {
        isRight = true; // so the boss starts by moving right
        levelManager = new LevelManager();// create new instance of level manager
    }
	
	// Update is called once per frame
	void Update () {

       

        if (transform.position.x < xMax && isRight == true) 
        {
            moveRight(); // call the move right method
        }
        if (transform.position.x >= xMax)
        {
            isRight = false; // reset isRight to false to stop the movement
        }
        if (!isRight)
        {
            moveLeft(); // start moving left
        }

        if (transform.position.x <= xMin)
        {
            isRight = true; // reset isRight to true so it will turn around again and move right
        }
    }

    void moveLeft()
    {
        transform.position = new Vector2(transform.position.x - bossSpeed * Time.deltaTime,
         transform.position.y); // create a new vector2 that will move the boss negatively along the x axis
    }

    void moveRight()
    {
        transform.position = new Vector2(transform.position.x + bossSpeed * Time.deltaTime,
          transform.position.y); // create a new vector2 that will move the boss positively along the x axis
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") // if the boss hits the player
        {
            levelManager.ChangeLevel("LevelsMenu"); // redirect back to level selection menu
        }
        /*
        if (other.gameObject.tag == "Seed") // if the boss hits the player
        {
            Destroy(other.gameObject); // destroy that seed object
        }
        */
    }
}
