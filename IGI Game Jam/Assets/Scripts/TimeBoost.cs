using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBoost : MonoBehaviour {

    public float speed;
    private TimeController timeController;
    private Controller controller;

    private AudioController audioController;

	// Use this for initialization
	void Start () {

        timeController = GameObject.Find("GameController").GetComponent<TimeController>();
        controller = GameObject.Find("GameController").GetComponent<Controller>();
        audioController = GameObject.Find("AudioClips").GetComponent<AudioController>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0, 1*speed, 0, Space.Self);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WhitePlayer" && controller.ControlingWhite())
        {
            timeController.IncreaseTime(5);
            audioController.PlayPowerUp();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "WhitePlayer" && !controller.ControlingWhite())
        {
            timeController.DecreaseTime(5);
            audioController.PlayBadPowerUp();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "BlackPlayer" && !controller.ControlingWhite())
        {
            timeController.IncreaseTime(5);
            audioController.PlayPowerUp();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "BlackPlayer" && controller.ControlingWhite())
        {
            timeController.DecreaseTime(5);
            audioController.PlayBadPowerUp();
            Destroy(gameObject);
        }
    }
}
