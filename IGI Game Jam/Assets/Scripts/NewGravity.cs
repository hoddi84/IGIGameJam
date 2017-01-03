using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGravity : MonoBehaviour
{

    public float range = 10f;
    public float mass;
    public float force;

    Rigidbody ownRb;

    void Start()
    {
        ownRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        Collider[] cols = Physics.OverlapSphere(transform.position, range);

        foreach (Collider c in cols)
        {
            Rigidbody rb = c.attachedRigidbody;
            if (rb != null && rb != ownRb)
            {
                Vector3 offset = transform.position - c.transform.position;
                Vector3 perpendicular = new Vector3(offset.y, -offset.x, 0);
                rb.AddForce(offset / offset.sqrMagnitude * mass);
                rb.AddForce(perpendicular / perpendicular.sqrMagnitude * force);
      
                if (rb.velocity.magnitude > 5)
                {
                    rb.velocity = rb.velocity / 2;
                }
          
            }
        }
    }
}
