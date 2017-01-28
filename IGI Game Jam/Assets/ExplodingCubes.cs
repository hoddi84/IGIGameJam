using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingCubes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WhitePlayer")
        {
            Debug.Log("WOE");
        }
    }
}
