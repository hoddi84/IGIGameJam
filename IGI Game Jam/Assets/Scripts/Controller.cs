using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public GameObject blackPlayer;
    public GameObject whitePlayer;

    private TimeController timeController;

    private Rigidbody rbBlack;
    private Rigidbody rbWhite;

    private Transform tfBlack;
    private Transform tfWhite;

    public float whiteSpeed = 1.5f;
    public float blackSpeed = 1.5f;

    public bool controlWhite;
    public bool controlBoth;

    private bool controlsActive;

    private bool canStartGame;

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

        timeController = gameObject.GetComponent<TimeController>();

        rbBlack = blackPlayer.GetComponent<Rigidbody>();
        rbWhite = whitePlayer.GetComponent<Rigidbody>();

        tfBlack = blackPlayer.GetComponent<Transform>();
        tfWhite = whitePlayer.GetComponent<Transform>();
	}

    void Update()
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
}
