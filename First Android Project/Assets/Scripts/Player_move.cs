using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player_move : MonoBehaviour {

    private int playerSpeed = 115;
    public static bool facingRight;
    public int playerJumpPower = 1250;
    private float moveX;
    private float testX;
    public bool isGrounded;
    public float distanceToBottomPlayer = 0.9f;
    public AudioManager audioManager;

    void start()
    {
        facingRight = false;
       // audioManager = new AudioManager();
        audioManager.Play("MainTheme");
    }
    

	
	// Update is called once per frame
	void FixedUpdate () {

        playerRaycast();
        PlayerMove();
		
	}

    void PlayerMove()
    {
        //controls

         KeyBoardMovement();
        // TouchMovements();

    }

    private void FlipPlayer()
    {
       
        //flip code
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale; // simply puts the game character facing the other way
    }

    public void Jump()
    {
        if (isGrounded == true) // only jump if the player is already on the ground
        {
           
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower); // character moves up
            isGrounded = false; // character is not grounded and therefore cannot jump

        }
        
    }

    void playerRaycast()
    {
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomPlayer && rayUp.collider.tag == "BreakBox")
        {
            Destroy(rayUp.collider.gameObject); // to destroy the breakable boxes
        }
            RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down); // to kill an enemy when jumped on
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomPlayer && rayDown.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            rayDown.collider.gameObject. GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);// move to the right after hit enemy
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
        }

        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomPlayer && rayDown.collider.tag != "Enemy")
        {
            isGrounded = true; // so the player can bounce on the enemy
        }


    }

    void TouchMovements() // touch control code
    {
        moveX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        playerSpeed = 35;

        // animations
        if (moveX != 0)
        {
            GetComponent<Animator>().SetBool("isMoving", true); // play the moving animation
        }
        else
        {
            GetComponent<Animator>().SetBool("isMoving", false); // play the idol animation
        }

        //player direction
        if (moveX < 0.0f && facingRight == false) // so the player is facing left when moving left
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)  // so the player is facing right when moving right
        {
            FlipPlayer();
        }
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
            moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y); // move the player



    }

    void KeyBoardMovement() // if the user is using a keyboard (mainly for testing purposes)
    {
        playerSpeed = 10; // set the player speed to 10
        testX = Input.GetAxis("Horizontal");
       
        if (Input.GetButtonDown("Jump") && isGrounded == true) // if the space bar is hit
        {
            Jump();
        }

        // animations
        if (testX != 0)
        {
            GetComponent<Animator>().SetBool("isMoving", true); // play the moving animation
        }
        else
        {
            GetComponent<Animator>().SetBool("isMoving", false); // play the idol animation
        }

      
        //player direction
        if (testX < 0.0f && facingRight == false) // so the player is facing left when moving left
        {
            FlipPlayer();
        }
        else if (testX > 0.0f && facingRight == true) // so the player is facing right when moving right
        {
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
        testX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y); // move the player
    }

}
