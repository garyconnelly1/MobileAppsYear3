using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
    public int bossScore;
    public GameObject door;

    // Use this for initialization
    void Start () {

       // bossScore = 50;

    }
	
	// Update is called once per frame
	void Update () {
        if (bossScore == 0)
        {
            Die();
        }
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Seed") // if the boss hits the player
        {
            Destroy(other.gameObject); // destroy that seed object
            bossScore -= 10;
        }
    }

    void Die()
    {
        Destroy(this.gameObject); // destroy the boss
        Destroy(door.gameObject); // destroy the door
    }
}
