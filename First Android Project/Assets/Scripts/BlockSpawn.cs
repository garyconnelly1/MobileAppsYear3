using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour { // This script is used in the endless runner level to spawn obstacles(Worms).

    public GameObject block;
    public float spawnRate = 2f;
    public float nextSpawn = 0.0f;
    public GameObject[] obstacles;
    public Transform spawnPoint;

    void Start()
    {
        nextSpawn = Time.time + spawnRate; // Initialise the first spawn time.
    }

	
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn) // If 2 seconds passes.
        {
            SpawnObstacle(); // Spawn a random obstacle object.
        }
	}

    void SpawnObstacle()
    {
        nextSpawn = Time.time + spawnRate; // Reset the timer.
        int randomObstacle = Random.Range(0, obstacles.Length); // Get a random index on the obstacles array.
        Instantiate(obstacles[randomObstacle], spawnPoint.position, Quaternion.identity); // Create the obstacle object.
    }
}
