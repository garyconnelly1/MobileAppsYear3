using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunner : MonoBehaviour {

    public int playerJumpPower = 1250;

    void Start()
    {
        GetComponent<Animator>().SetBool("isMoving", true); // Play the moving animation.
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)) // When the up arrow is pressed.
        {
            Jump(); // Invoke jump method.
        }
	}

    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower); // Move the player upward.
    }
}
