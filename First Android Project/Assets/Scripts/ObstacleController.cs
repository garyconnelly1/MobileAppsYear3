using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public float moveSpeed = -5f;

    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        levelManager = new LevelManager();// create new instance of level manager
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,
            transform.position.y);

        if (transform.position.x < -23f)
            Destroy(gameObject);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
       // Debug.Log("Hit");
        if (other.gameObject.tag == "EndlessRunnerHamster")
        {
            levelManager.ChangeLevel("LevelsMenu");
            //Debug.Log("Hit Hamster");
        }
    }
}
