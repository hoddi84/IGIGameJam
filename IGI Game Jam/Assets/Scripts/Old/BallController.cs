using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody rb;

    private Vector3 down;

    private bool canJump;
    public float jumpPower;

    private CubeExploder exploder1;
    private CubeExploder exploder2;

	void Start () {

        rb = GetComponent<Rigidbody>();
        down = new Vector3(0, -1);

        exploder1 = GameObject.Find("ExplodingCube 1").GetComponent<CubeExploder>();
        exploder2 = GameObject.Find("ExplodingCube 2").GetComponent<CubeExploder>();
	}
	
	void Update () {
		
	}

    void FixedUpdate ()
    {
        /* 
         * Using raycast to detect if we are touching the ground
         * to limit our jumping.  
         */
        if (Physics.Raycast(transform.position, down, 0.151f))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        /* 
         * Simple controls for movement using velocity change. 
         */
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-1, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(1, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            rb.AddForce(0, jumpPower, 0, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        if (contact.otherCollider.tag == "ExplodingCube 1")
        {
            exploder1.Explode(contact.point);
        }
        else if (contact.otherCollider.tag == "ExplodingCube 2")
        {
            exploder2.Explode(contact.point);
        }
    }
}
