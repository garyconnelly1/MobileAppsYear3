using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour {

    public float moveSpeed = 5f;
    private bool isLeft;

    // Use this for initialization
    void Start () {
        isLeft = Player_move.facingRight; // initialise the direction of the player by accessing the static variable on Player_move
	}
	
	// Update is called once per frame
	void Update () {

        if (!isLeft) // if hamster is facing right
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,
           transform.position.y); // move the seed accross the screen on the positive x axis
        }
        else
        { // otherwise the hamster is facing left
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime,
           transform.position.y); // move the seed accross the screen on the negative x axis
        }
        

    }
}
