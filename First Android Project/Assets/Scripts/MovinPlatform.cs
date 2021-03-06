﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovinPlatform : MonoBehaviour {

    private Vector3 posA;

    private Vector3 posB;

    private Vector3 nextPosition;

    public float speed;

    public Transform childTransform; // To get the current position of the platform.

    public Transform transformB;// To get the position of the spot we want the platform to move to.

	// Use this for initialization
	void Start () {

        posA = childTransform.localPosition;// Local position of platform.
        posB = transformB.localPosition;// Local position of spot to move to.
        nextPosition = posB;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPosition, speed * Time.deltaTime); // Moving the platform to the next position.

        if (Vector3.Distance(childTransform.localPosition, nextPosition) <= 0.1) // If distance between current position and next position < 0.1 change direction.
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        nextPosition = nextPosition != posA ? posA : posB;// If statement to change direction of platform.
    }
}
