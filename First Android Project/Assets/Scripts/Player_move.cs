using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player_move : MonoBehaviour { // Class that controlls the players movements.
    // Variables.
    private int playerSpeed = 115;
    public static bool facingRight;
    public int playerJumpPower = 1250;
    private float moveX;
    private float testX;
    public bool isGrounded;
    public float distanceToBottomPlayer = 0.9f;
    public AudioManager audioManager;
    public bool isTouch = false;

    void start()
    {
        facingRight = false;
        audioManager.Play("MainTheme");
    }
    

	
	// Update is called once per frame
	void FixedUpdate () {

        playerRaycast(); // Start the player Raycast.
        PlayerMove(); // Move the player.
		
	}

    void PlayerMove()
    {
        if (PlayerPrefs.GetString("Control") == "Touch") // Depending on what the user selected earlier.
        {
            TouchMovements(); // Trigger touch controlls method.
        }
        else
        {
            KeyBoardMovement(); // Trigger keyboard controlls method.
        }
        
        // 

    }

    private void FlipPlayer()
    {
       
        // Flip code.
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale; // Simply puts the game character facing the other way.
    }

    public void Jump()
    {
        if (isGrounded == true) // Only jump if the player is already on the ground.
        {
           
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower); // Character moves up.
            isGrounded = false; // Character is not grounded and therefore cannot jump.

        }
        
    }

    void playerRaycast()
    {
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomPlayer && rayUp.collider.tag == "BreakBox")
        {
            Destroy(rayUp.collider.gameObject); // To destroy the breakable boxes.
        }
            RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down); // To kill an enemy when jumped on.
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomPlayer && rayDown.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            rayDown.collider.gameObject. GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);// Move to the right after hit enemy.
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
        }

        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomPlayer && rayDown.collider.tag != "Enemy")
        {
            isGrounded = true; // So the player can bounce on the enemy
        }


    }

    void TouchMovements() // Touch control code.
    {
        moveX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        playerSpeed = 50;

        if (moveX != 0) // Animations.
        {
            GetComponent<Animator>().SetBool("isMoving", true); // Play the moving animation.
        }
        else
        {
            GetComponent<Animator>().SetBool("isMoving", false); // Play the idol animation.
        }

        // Player direction.
        if (moveX < 0.0f && facingRight == false) // So the player is facing left when moving left.
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)  // So the player is facing right when moving right.
        {
            FlipPlayer();
        }
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
            moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y); // Move the player.



    }

    void KeyBoardMovement() // If the user is using a keyboard.
    {
        playerSpeed = 10; // Set the player speed to 10.
        testX = Input.GetAxis("Horizontal");
       
        if (Input.GetButtonDown("Jump") && isGrounded == true) // If the space bar is hit.
        {
            Jump();
        }

        if (testX != 0)  // Animations.
        {
            GetComponent<Animator>().SetBool("isMoving", true); // Play the moving animation.
        }
        else
        {
            GetComponent<Animator>().SetBool("isMoving", false); // Play the idol animation.
        }

      
        // Player direction.
        if (testX < 0.0f && facingRight == false) // So the player is facing left when moving left.
        {
            FlipPlayer();
        }
        else if (testX > 0.0f && facingRight == true) // So the player is facing right when moving right.
        {
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
        testX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y); // Move the player.
    }

}
