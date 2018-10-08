using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovinPlatform : MonoBehaviour {

    private Vector3 posA;

    private Vector3 posB;

    private Vector3 nextPosition;

    public float speed;

    public Transform childTransform;

    public Transform transformB;

	// Use this for initialization
	void Start () {

        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nextPosition = posB;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPosition, speed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition, nextPosition) <= 0.1)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        nextPosition = nextPosition != posA ? posA : posB;
    }
}
