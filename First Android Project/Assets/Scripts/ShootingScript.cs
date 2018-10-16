using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour {
    /*
    public float damage = 10f;

    Touch touch;

    Transform firePoint;

	// Use this for initialization
	void Start () {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.Log("No child found!");
        }
        else
        {
            Debug.Log("FirePoint found!");
        }
	}
	
	// Update is called once per frame
	void Update () {
       // touch = Input.GetTouch(0);
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }

       
    }

    void Shoot()
    {
        // Debug.Log("touch position " + touch);
        /*  Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
              Camera.main.ScreenToWorldPoint(Input.mousePosition).y); // get position of touch point

          Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y); // get the fire point

          RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100);

          Debug.DrawLine(firePointPosition, mousePosition);  




    }*/




    public GameObject bullet;
    public Transform spawnPoint;

    void Update()
    {
        // touch = Input.GetTouch(0);
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }


    }

    void Shoot()
    {
        Debug.Log("shoot");
        Instantiate(bullet, spawnPoint.position, Quaternion.identity); // create the obstacle object
    }

    }
