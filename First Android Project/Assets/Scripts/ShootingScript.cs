using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class ShootingScript : MonoBehaviour {
    public float shootingPosition;
    public GameObject bullet;
    public Transform spawnPoint;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && transform.position.x > shootingPosition) // Player must be at a certain point in the level before they can shoot.
        {
            Shoot(); // Call shoot method.
        }


    }

    public void Shoot()
    {
        if (transform.position.x > shootingPosition)
        {
            Instantiate(bullet, spawnPoint.position, Quaternion.identity); // Create the seed object.
        }
       
    }

  

}
