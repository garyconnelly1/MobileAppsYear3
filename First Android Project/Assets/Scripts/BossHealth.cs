using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
    public int bossScore;
    public GameObject door;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (bossScore == 0) // If the Boss' score goes beneath 0 
        {
            Die(); // Destroy the Boss object.
        }
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Seed") // If the bullet hits the Boss.
        {
            Destroy(other.gameObject); // Destroy that seed object.
            bossScore -= 10; // Reduce the Boss' score.
        }
    }

    void Die()
    {
        Destroy(this.gameObject); // Destroy the boss.
        Destroy(door.gameObject); // Destroy the door.
    }
}
