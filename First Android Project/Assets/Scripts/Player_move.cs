using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_move : MonoBehaviour {

    private int playerSpeed = 10;
    //private bool facingRight = false;
    public static bool facingRight = false;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    public float distanceToBottomPlayer = 0.9f;
    

	
	// Update is called once per frame
	void Update () {

        playerRaycast();
        PlayerMove();
		
	}

    void PlayerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal");
       // Debug.Log(moveX);
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        //animation
        //player direction
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (
            moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    private void FlipPlayer()
    {
        //flip code
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Jump()
    {
        //Debug.Log("Inside jump");
        //jumping code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void OnCollisionEnter2D (Collision2D col)
    {
       
    }

    void playerRaycast()
    {
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomPlayer && rayUp.collider.tag == "BreakBox")
        {
            Destroy(rayUp.collider.gameObject);
        }
            RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomPlayer && rayDown.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            //Destroy(hit.collider.gameObject);
            rayDown.collider.gameObject. GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);// move to the right after hit enemy
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
        }

        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomPlayer && rayDown.collider.tag != "Enemy")
        {
            isGrounded = true;
        }


    }

    public void SayHellLeft()
    {
        
    }

    public void SayHellRight()
    {
      
    }

}
