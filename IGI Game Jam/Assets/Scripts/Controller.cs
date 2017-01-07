﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public GameObject blackPlayer;
    public GameObject whitePlayer;

    private Rigidbody rbBlack;
    private Rigidbody rbWhite;

    private Transform tfBlack;
    private Transform tfWhite;

    public float whiteSpeed = 1.5f;
    public float blackSpeed = 1.5f;

    public bool controlWhite;
    public bool controlBoth;

    private enum Mode
    {
        Normal,
        Opposite
    }

	// Use this for initialization
	void Start () {

        controlWhite = true;
        controlBoth = true;

        rbBlack = blackPlayer.GetComponent<Rigidbody>();
        rbWhite = whitePlayer.GetComponent<Rigidbody>();

        tfBlack = blackPlayer.GetComponent<Transform>();
        tfWhite = whitePlayer.GetComponent<Transform>();
	}

    // Update is called once per frame


    void Update()
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

    void ControlBlack(Mode mode)
    {
        if (mode == Mode.Normal)
        {
            if (Input.GetKey(KeyCode.A))
            {
                tfBlack.position += new Vector3(-1, 0, 0) * blackSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                tfBlack.position += new Vector3(1, 0, 0) * blackSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                tfBlack.position += new Vector3(0, 0, 1) * blackSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                tfBlack.position += new Vector3(0, 0, -1) * blackSpeed * Time.deltaTime;
            }
        }
        else if (mode == Mode.Opposite)
        {
            if (Input.GetKey(KeyCode.A))
            {
                tfBlack.position += new Vector3(1, 0, 0) * blackSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                tfBlack.position += new Vector3(-1, 0, 0) * blackSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                tfBlack.position += new Vector3(0, 0, -1) * blackSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                tfBlack.position += new Vector3(0, 0, 1) * blackSpeed * Time.deltaTime;
            }
        }
    }

    void ControlWhite(Mode mode)
    {
        if (mode == Mode.Normal)
        {
            if (Input.GetKey(KeyCode.A))
            {
                tfWhite.position += new Vector3(-1, 0, 0) * whiteSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                tfWhite.position += new Vector3(1, 0, 0) * whiteSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                tfWhite.position += new Vector3(0, 0, 1) * whiteSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                tfWhite.position += new Vector3(0, 0, -1) * whiteSpeed * Time.deltaTime;
            }
        }
        else if (mode == Mode.Opposite)
        {
            if (Input.GetKey(KeyCode.A))
            {
                tfWhite.position += new Vector3(1, 0, 0) * whiteSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                tfWhite.position += new Vector3(-1, 0, 0) * whiteSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                tfWhite.position += new Vector3(0, 0, -1) * whiteSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                tfWhite.position += new Vector3(0, 0, 1) * whiteSpeed * Time.deltaTime;
            }
        }
    }
}