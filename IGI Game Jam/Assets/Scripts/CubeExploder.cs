using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour {

    private Rigidbody[] rbs;
    private Rigidbody center;
    public GameObject explosionCenter;

    public float explosionForce;
    public float explosionRadius;
    public float upwardsModifier;

	// Use this for initialization
	public void Explode (Vector3 explosionPos) { 

        rbs = GetComponentsInChildren<Rigidbody>();
        center = explosionCenter.GetComponent<Rigidbody>();

        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && rb.tag != "Player")
            {
                rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius, upwardsModifier);
                hit.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                hit.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
