using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour {


    private float endTime;
    private float startTime;
    private int timeLeft;
    public float durationTime;
    public string timeLeftText;
    public string timeOverText;

    private Text text;
    public GameObject textTimer;
    private Controller controller;

    private int minutes;
    private int seconds;
    private string printTime;

    private bool timeOver;

    public string nextScene;

	// Use this for initialization
	void Start () {


        timeOver = true; 
        endTime = Time.time + durationTime;
        text = textTimer.GetComponent<Text>();
        controller = GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!timeOver)
        {
            timeLeft = (int)(endTime - Time.time + startTime);

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
        else
        {
            startTime += Time.deltaTime;
        }
	}

    void TimeOver()
    {
        text.text = timeOverText;
        controller.DisableControls();
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2.0f);
        if (SceneManager.GetActiveScene().name == "jinjang")
        {
            SceneManager.LoadScene("jinjang");
        }
        if (SceneManager.GetActiveScene().name == "jinjang3")
        {
            SceneManager.LoadScene("jinjang3");
        }  
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2.0f);
        if (SceneManager.GetActiveScene().name == "jinjang")
        {
            SceneManager.LoadScene("jinjang3");
        }
        if (SceneManager.GetActiveScene().name == "jinjang3")
        {
            SceneManager.LoadScene("StartScreen");
        } 
    }

    public void GameWon(string msg)
    {
        timeOver = true;
        text.text = msg;
        StartCoroutine(NextLevel());
    }

    public void IncreaseTime(int time)
    {
        endTime += time;
    }

    public void DecreaseTime(int time)
    {
        endTime -= time;
    }

    public void StartGame()
    {
        timeOver = false;
    }
}
