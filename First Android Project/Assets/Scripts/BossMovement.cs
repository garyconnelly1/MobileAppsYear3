using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    public int bossSpeed;
    public float xMax;
    public float xMin;
    private bool isRight;

    // Use this for initialization
    void Start () {
        isRight = true; // so the boss starts by moving right
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
}
