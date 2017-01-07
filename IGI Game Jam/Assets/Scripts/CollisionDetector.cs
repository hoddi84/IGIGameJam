using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour {

    public GameObject gameController;
    private TimeController timeController;
    private Controller controller;

	// Use this for initialization
	void Start () {

        timeController = gameController.GetComponent<TimeController>();
        controller = gameController.GetComponent<Controller>();
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
