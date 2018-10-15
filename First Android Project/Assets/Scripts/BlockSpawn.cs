using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour {

    public GameObject block;
    float randX;
    //Vector2 spawnPoint;
    public float spawnRate = 2f;
    public float nextSpawn = 0.0f;

    public GameObject[] obstacles;

    public Transform spawnPoint;

    public float timeToBoost = 5f;
    public float nextBoost;

    void Start()
    {
        Time.timeScale = 1f;
        nextSpawn = Time.time + spawnRate;
    }

	
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn)
        {
            SpawnObstacle(); ;

           /* if (Time.unscaledTime > nextBoost)
               BoostTime(); */
        }
	}

    void SpawnObstacle()
    {
        nextSpawn = Time.time + spawnRate;
        int randomObstacle = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomObstacle], spawnPoint.position, Quaternion.identity);
        //Time.timeScale += 0.25f;

    }

    /*
    void BoostTime()
    {
        nextBoost = Time.unscaledTime + timeToBoost;
        Time.timeScale += 0.25f;
    }
    */
}
