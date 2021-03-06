﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public GameObject blackPlayer;
    public GameObject whitePlayer;

    private TimeController timeController;

    private ExploderController exploderWhite;
    private ExploderController exploderBlack;

    private Rigidbody rbBlack;
    private Rigidbody rbWhite;

    private Transform tfBlack;
    private Transform tfWhite;

    private ExploderController whiteExploController;
    private ExploderController blackExploController;

    private Text explosionCount;
    public string explosionText;

    public float whiteSpeed = 1.5f;
    public float blackSpeed = 1.5f;

    public bool controlWhite;
    public bool controlBoth;

    private bool controlsActive;

    private bool canStartGame;

    private bool switchEnabled;

    private enum Mode
    {
        Normal,
        Opposite
    }

	// Use this for initialization
	void Start () {

        controlWhite = true;
        controlBoth = true;
        controlsActive = true;

        switchEnabled = false;

        timeController = gameObject.GetComponent<TimeController>();

        rbBlack = blackPlayer.GetComponent<Rigidbody>();
        rbWhite = whitePlayer.GetComponent<Rigidbody>();

        tfBlack = blackPlayer.GetComponent<Transform>();
        tfWhite = whitePlayer.GetComponent<Transform>();

        exploderWhite = whitePlayer.GetComponent<ExploderController>();
        exploderBlack = blackPlayer.GetComponent<ExploderController>();

        explosionCount = GameObject.Find("NumberOfExplo").GetComponent<Text>();
        whiteExploController = whitePlayer.GetComponent<ExploderController>();
        blackExploController = blackPlayer.GetComponent<ExploderController>();

        ActivateExploder(controlWhite);
        AmountOfExplosions(controlWhite);
	}

    void Update()
    {
        if (switchEnabled)
        {
            if (controlWhite)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    controlWhite = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    controlWhite = true;
                }
            }
        }

        ActivateExploder(controlWhite);
        AmountOfExplosions(controlWhite);
    }

    void FixedUpdate()
    {
        if (controlsActive)
        {
            if (controlWhite)
            {
                ControlWhite(Mode.Normal);
            }
            else
            {
                ControlBlack(Mode.Normal);
            }

            if (controlWhite && controlBoth)
            {
                ControlWhite(Mode.Normal);
                ControlBlack(Mode.Opposite);
            }

            if (!controlWhite && controlBoth)
            {
                ControlBlack(Mode.Normal);
                ControlWhite(Mode.Opposite);
            }
        }
    }

    void ControlBlack(Mode mode)
    {
        if (mode == Mode.Normal)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rbBlack.velocity = new Vector3(-1 * blackSpeed, 0, 0);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rbBlack.velocity = new Vector3(1 * blackSpeed, 0, 0);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rbBlack.velocity = new Vector3(0, 0, 1 * blackSpeed);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rbBlack.velocity = new Vector3(0, 0, -1 * blackSpeed);
                timeController.StartGame();
            }
            else
            {
                rbBlack.velocity = new Vector3(0, 0, 0);
            }
        }
        else if (mode == Mode.Opposite)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rbBlack.velocity = new Vector3(1 * blackSpeed, 0, 0);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rbBlack.velocity = new Vector3(-1 * blackSpeed, 0, 0);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rbBlack.velocity = new Vector3(0, 0, -1 * blackSpeed);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rbBlack.velocity = new Vector3(0, 0, 1 * blackSpeed);
                timeController.StartGame();
            }
            else
            {
                rbBlack.velocity = new Vector3(0, 0, 0);
            }
        }
    }

    void ControlWhite(Mode mode)
    {
        if (mode == Mode.Normal)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rbWhite.velocity = new Vector3(-1 * whiteSpeed, 0, 0);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rbWhite.velocity = new Vector3(1 * whiteSpeed, 0, 0);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rbWhite.velocity = new Vector3(0, 0, 1 * whiteSpeed);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rbWhite.velocity = new Vector3(0, 0, -1 * whiteSpeed);
                timeController.StartGame();
            }
            else
            {
                rbWhite.velocity = new Vector3(0, 0, 0);
            }
        }
        else if (mode == Mode.Opposite)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rbWhite.velocity = new Vector3(1 * whiteSpeed, 0, 0);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rbWhite.velocity = new Vector3(-1 * whiteSpeed, 0, 0);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rbWhite.velocity = new Vector3(0, 0, -1 * whiteSpeed);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rbWhite.velocity = new Vector3(0, 0, 1 * whiteSpeed);
                timeController.StartGame();
            }
            else
            {
                rbWhite.velocity = new Vector3(0, 0, 0);
            }
        }
    }

    public void DisableControls()
    {
        controlsActive = false;
        rbWhite.velocity = new Vector3(0, 0, 0);
        rbBlack.velocity = new Vector3(0, 0, 0);
    }

    public bool ControlingWhite()
    {
        if (controlWhite)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void ActivateExploder(bool whiteActive)
    {
        if (whiteActive)
        {
            exploderWhite.enabled = true;
            exploderBlack.enabled = false;
        }
        else
        {
            exploderWhite.enabled = false;
            exploderBlack.enabled = true;
        }
    }

    void AmountOfExplosions(bool whiteActive)
    {
        if (whiteActive)
        {
            explosionCount.text = explosionText + ":" + whiteExploController.GetExplosionAmount();
        }
        else
        {
            explosionCount.text = explosionText + ":" + blackExploController.GetExplosionAmount();
        }
    }
}
