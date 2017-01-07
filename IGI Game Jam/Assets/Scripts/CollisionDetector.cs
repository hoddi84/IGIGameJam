using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour {

    private TimeController timeController;
    private Controller controller;

	// Use this for initialization
	void Start () {

        timeController = GameObject.Find("GameController").GetComponent<TimeController>();
        controller = GameObject.Find("GameController").GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlackPlayer")
        {
            timeController.GameWon("Game Won");
            controller.DisableControls();
        }
    }
}
