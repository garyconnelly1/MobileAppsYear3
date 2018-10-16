using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour {

    public float moveSpeed = 5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,
           transform.position.y); // move the seed accross the screen on the x axis

    }
}
