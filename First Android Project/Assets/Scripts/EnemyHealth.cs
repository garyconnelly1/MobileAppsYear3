using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        if (gameObject.transform.position.y < -20)
        {
            Destroy(gameObject); // Simply destroy the enemy object when it falls off the platform.
        }

    }
}
