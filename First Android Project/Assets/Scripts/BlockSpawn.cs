using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour {

    public GameObject block;
    public float spawnRate = 2f;
    public float nextSpawn = 0.0f;
    public GameObject[] obstacles;
    public Transform spawnPoint;

    void Start()
    {
        nextSpawn = Time.time + spawnRate; // initialise the first spawn time
    }

	
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn) // if 2 seconds passes
        {
            SpawnObstacle(); // spawn a random obstacle object
        }
	}

    void SpawnObstacle()
    {
        nextSpawn = Time.time + spawnRate; // reset the timer
        int randomObstacle = Random.Range(0, obstacles.Length); // get a random index on the obstacles array
        Instantiate(obstacles[randomObstacle], spawnPoint.position, Quaternion.identity); // create the obstacle object
    }
}
