using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public int enemySpeed;
    public int xMove;
    public float hitDistance = 0.7f;

    private LevelManager levelManager; // Get handle on LevelManager object.

    void Start()
    {
        levelManager = new LevelManager();// Create new instance of level manager.
    }




    // Update is called once per frame
    void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMove, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * enemySpeed;

        if (hit.distance < hitDistance)
        {
            flip();
            if (hit.collider.tag == "Player") // If the enemy hits the player.
            {
                Player_move.facingRight = false; // To reset the direction of the player.
                Destroy(hit.collider.gameObject); // Kill the player and redirect to levels menu.
                levelManager.ChangeLevel("LevelsMenu");
            }
        }
       
	}
    void flip () // Flip the enemy when it reaches a certain position.
    {
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

        if (xMove > 0)
        {
            xMove = -1;
        }
        else
        {
            xMove = 1;
        }
    }
}

 
