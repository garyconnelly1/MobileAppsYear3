using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour {
    public float shootingPosition;
    public GameObject bullet;
    public Transform spawnPoint;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && transform.position.x > shootingPosition) // player must be at a certain point in the level before they can shoot
        {
            Shoot(); // call shoot method
        }


    }

    void Shoot()
    {
        Instantiate(bullet, spawnPoint.position, Quaternion.identity); // create the seed object
    }

    }
