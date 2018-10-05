using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    
    
    

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y < -7)
        {
            Die();
            //Debug.Log(hasDied);

        }

       
	}

    void Die() {
        SceneManager.LoadScene("sideScroller1");
        //yield return null;
    }
}
