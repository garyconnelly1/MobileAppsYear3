using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour {

    private Vector3 posA;

    private Vector3 posB;

    private Vector3 nextPosition;

    public float speed;

    public Transform childTransform;// to get the current position of the platform

    public Transform transformB;// to get the position of the spot we want the platform to move to


    // Use this for initialization
    void Start () {

        posA = childTransform.localPosition;// local position of platform
        posB = transformB.localPosition;// local position of spot to move to
        nextPosition = posB;

    }
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPosition, speed * Time.deltaTime);//moving the platform to the next position

    }


}
