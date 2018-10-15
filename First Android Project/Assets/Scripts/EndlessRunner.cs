﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunner : MonoBehaviour {

    public int playerJumpPower = 1250;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)) // when the up arrow is pressed
        {
            Jump(); // invoke jump method
        }
	}

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower); // move the player upward
    }
}
