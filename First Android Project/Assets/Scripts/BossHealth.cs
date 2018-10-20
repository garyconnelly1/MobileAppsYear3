using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Inside boss health");
        if (other.gameObject.tag == "Seed") // if the boss hits the player
        {
            Destroy(other.gameObject); // destroy that seed object
        }
    }
}
