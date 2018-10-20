using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    public int bossSpeed;
  //  public int xMove;
    public float xMax;
    public float xMin;
    private bool isRight;

    // Use this for initialization
    void Start () {
        isRight = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < xMax && isRight == true)
        {
            moveRight();
            Debug.Log(transform.position.x);
        }
        if (transform.position.x >= xMax)
        {
            Debug.Log("isRight = false");
            isRight = false;
           
        }
        if (!isRight)
        {
            moveLeft();
        }

        if (transform.position.x <= xMin)
        {
            isRight = true;
        }
        

       // gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMove, 0) * bossSpeed;
       

    }

    void moveLeft()
    {
        transform.position = new Vector2(transform.position.x - bossSpeed * Time.deltaTime,
         transform.position.y);

    }

    void moveRight()
    {
        transform.position = new Vector2(transform.position.x + bossSpeed * Time.deltaTime,
          transform.position.y);

    }
}
