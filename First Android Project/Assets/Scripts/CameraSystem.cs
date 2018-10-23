﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    public GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player"); // find the object to clamp the camera to
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z); // so the camera follows the player object
    }
}
