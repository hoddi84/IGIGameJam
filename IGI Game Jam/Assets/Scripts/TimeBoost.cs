using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBoost : MonoBehaviour {

    public float speed;
    private TimeController timeController;

	// Use this for initialization
	void Start () {

        timeController = GameObject.Find("GameController").GetComponent<TimeController>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0, 1*speed, 0, Space.Self);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WhitePlayer")
        {
            timeController.IncreaseTime(5);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "BlackPlayer")
        {
            timeController.DecreaseTime(5);
            Destroy(gameObject);
        }
    }
}
