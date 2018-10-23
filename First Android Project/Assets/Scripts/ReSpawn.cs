﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour {
    public GameObject sp1;
    public GameObject sp2;
    public static bool canTransport;

    void Start()
    {
        canTransport = true;
        sp1 = this.gameObject;
    }

    
	
	void OnTriggerEnter2D(Collider2D trig)
    {
       
        if (canTransport == true)
        {
            trig.gameObject.transform.position = sp2.gameObject.transform.position;
            canTransport = false;
        }
       
    }

    void OnTriggerExit2D(Collider2D trig)
    {
        canTransport = true;
    }
}
