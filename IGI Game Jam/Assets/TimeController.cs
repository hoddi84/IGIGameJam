using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {


    private float endTime;
    private int timeLeft;

    private Text text;
    public GameObject textTimer;

    private int minutes;
    private int seconds;
    private string printTime;

    private bool timeOver;

	// Use this for initialization
	void Start () {

        timeOver = false;
        endTime = Time.time + 5.0f;
        text = textTimer.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

        if (!timeOver)
        {
            timeLeft = (int)(endTime - Time.time);

            minutes = Mathf.FloorToInt(timeLeft / 60F);
            seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
            printTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            text.text = "Time Left: " + printTime.ToString();

            if (timeLeft == 0)
            {
                timeOver = true;
            }
        }
        else
        {
            text.text = "Time Over";
        }
	}
}
