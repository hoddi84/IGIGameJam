using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour {


    private float endTime;
    private int timeLeft;
    public float durationTime;
    public string timeLeftText;
    public string timeOverText;

    private Text text;
    public GameObject textTimer;

    private int minutes;
    private int seconds;
    private string printTime;

    private bool timeOver;

	// Use this for initialization
	void Start () {


        timeOver = false;
        endTime = Time.time + durationTime;
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

            text.text = timeLeftText + ": " + printTime.ToString();

            if (timeLeft == 0)
            {
                timeOver = true;
                TimeOver();
            }
        }
	}

    void TimeOver()
    {
        text.text = timeOverText;
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("StartScreen");
    }
}
