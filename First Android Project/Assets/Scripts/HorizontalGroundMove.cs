using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalGroundMove : MonoBehaviour {
    public int groundSpeed;
    public int xMove;
    public float flipDistance = 0.7f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

         RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMove, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * groundSpeed;
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMove, 0));
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * groundSpeed;
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMove,0));
       

        if (hit.distance < flipDistance)
        {
            flip();
            /*
            if (hit.collider.tag == "Player")
            {
                Destroy(hit.collider.gameObject);
                levelManager.ChangeLevel("LevelsMenu");
            }
            */
        }

    }
    void flip()
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
