using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //Allows us to use SceneManager

public class HumanPlayer : MonoBehaviour
{
    private Animator animator;

    public GameObject humanPlayer;
    public GameObject orcPlayer;

    private TimeController timeController;

    private ExploderController exploderOrc;
    private ExploderController exploderHuman;

    private Rigidbody rbHuman;
    private Rigidbody rbOrc;

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
    void Start()
    {
        animator = GetComponent<Animator>();
        controlWhite = true;
        controlBoth = true;
        controlsActive = true;

        timeController = gameObject.GetComponent<TimeController>();

        rbHuman = humanPlayer.GetComponent<Rigidbody>();
        rbOrc = orcPlayer.GetComponent<Rigidbody>();

        tfBlack = humanPlayer.GetComponent<Transform>();
        tfWhite = orcPlayer.GetComponent<Transform>();

     //   exploderOrc = orcPlayer.GetComponent<ExploderController>();
      //  exploderHuman = humanPlayer.GetComponent<ExploderController>();

       // ActivateExploder(controlWhite);
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

     //   ActivateExploder(controlWhite);
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
                rbHuman.velocity = new Vector3(-1 * blackSpeed, 0, 0);
                timeController.StartGame();
                animator.SetTrigger("HumanLeft");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rbHuman.velocity = new Vector3(1 * blackSpeed, 0, 0);
                timeController.StartGame();
                animator.SetTrigger("HumanRight");
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rbHuman.velocity = new Vector3(0, 0, 1 * blackSpeed);
                timeController.StartGame();
                animator.SetTrigger("HumanUp");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rbHuman.velocity = new Vector3(0, 0, -1 * blackSpeed);
                timeController.StartGame();
                animator.SetTrigger("HumanDown");
            }
            else
            {
                rbHuman.velocity = new Vector3(0, 0, 0);
            }
        }
        else if (mode == Mode.Opposite)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rbHuman.velocity = new Vector3(1 * blackSpeed, 0, 0);
                timeController.StartGame();
                animator.SetTrigger("HumanRight");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rbHuman.velocity = new Vector3(-1 * blackSpeed, 0, 0);
                animator.SetTrigger("HumanLeft");
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rbHuman.velocity = new Vector3(0, 0, -1 * blackSpeed);
                timeController.StartGame();
                animator.SetTrigger("HumanDown");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rbHuman.velocity = new Vector3(0, 0, 1 * blackSpeed);
                timeController.StartGame();
                animator.SetTrigger("HumanUp");
            }
            else
            {
                rbHuman.velocity = new Vector3(0, 0, 0);
            }
        }
    }

    void ControlWhite(Mode mode)
    {
        if (mode == Mode.Normal)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rbOrc.velocity = new Vector3(-1 * whiteSpeed, 0, 0);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rbOrc.velocity = new Vector3(1 * whiteSpeed, 0, 0);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rbOrc.velocity = new Vector3(0, 0, 1 * whiteSpeed);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rbOrc.velocity = new Vector3(0, 0, -1 * whiteSpeed);
                timeController.StartGame();
            }
            else
            {
                rbOrc.velocity = new Vector3(0, 0, 0);
            }
        }
        else if (mode == Mode.Opposite)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rbOrc.velocity = new Vector3(1 * whiteSpeed, 0, 0);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rbOrc.velocity = new Vector3(-1 * whiteSpeed, 0, 0);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rbOrc.velocity = new Vector3(0, 0, -1 * whiteSpeed);
                timeController.StartGame();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rbOrc.velocity = new Vector3(0, 0, 1 * whiteSpeed);
                timeController.StartGame();
            }
            else
            {
                rbOrc.velocity = new Vector3(0, 0, 0);
            }
        }
    }

    public void DisableControls()
    {
        controlsActive = false;
        rbOrc.velocity = new Vector3(0, 0, 0);
        rbHuman.velocity = new Vector3(0, 0, 0);
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
/*
    void ActivateExploder(bool whiteActive)
    {
        if (whiteActive)
        {
            exploderOrc.enabled = true;
            exploderHuman.enabled = false;
        }
        else
        {
            exploderOrc.enabled = false;
            exploderHuman.enabled = true;
        }
    } */
}
