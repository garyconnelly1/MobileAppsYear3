using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public int enemySpeed;
    public int xMove;
    public float hitDistance = 0.7f;


	
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMove, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * enemySpeed;

        if (hit.distance < hitDistance)
        {
            flip();
            if (hit.collider.tag == "Player")
            {
                Destroy(hit.collider.gameObject);
            }
        }
       
	}
    void flip ()
    {
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

 
