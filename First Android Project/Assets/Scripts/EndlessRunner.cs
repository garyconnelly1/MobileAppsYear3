using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunner : MonoBehaviour {

    private Vector2 targetPos;
    public int playerJumpPower = 1250;
    public float jumpHeight = 5f;
    public bool isGrounded = true;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           
            Debug.Log("Up Arrow");
            Jump();
        }
	}

    void Jump()
    {
        Debug.Log("Inside jump");
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }
}
