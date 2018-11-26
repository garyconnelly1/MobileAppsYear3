using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    public int bossSpeed;
    public float xMax;
    public float xMin;
    private bool isRight;
    private LevelManager levelManager; // Get handle on LevelManager object.

    // Use this for initialization
    void Start () {
        isRight = true; // So the boss starts by moving right.
        levelManager = new LevelManager();// Create new instance of level manager.
    }
	
	// Update is called once per frame
	void FixedUpdate () {

       

        if (transform.position.x < xMax && isRight == true) 
        {
            moveRight(); // Call the move right method.
        }
        if (transform.position.x >= xMax)
        {
            Flip();
            isRight = false; // Reset isRight to false to stop the movement.
        }
        if (!isRight)
        {
            moveLeft(); // Start moving left.
        }

        if (transform.position.x <= xMin)
        {
            Flip();
            isRight = true; // Reset isRight to true so it will turn around again and move right.
        }
    }

    void moveLeft()
    {
        transform.position = new Vector2(transform.position.x - bossSpeed * Time.deltaTime,
         transform.position.y); // Create a new vector2 that will move the boss negatively along the x axis.
    }

    void moveRight()
    {
        transform.position = new Vector2(transform.position.x + bossSpeed * Time.deltaTime,
          transform.position.y); // Create a new vector2 that will move the boss positively along the x axis.
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") // If the boss hits the player.
        {
            Player_move.facingRight = false; // Reset the directiom the player is facing.
            levelManager.ChangeLevel("LevelsMenu"); // Redirect back to level selection menu.
        }
    }

    void Flip() // Flip the boss.
    {
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
