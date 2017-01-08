using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderController : MonoBehaviour {

    private List<GameObject> list;
    public GameObject prefabExplosion;
    private GameObject destroyedExplosion;

	// Use this for initialization
    void Awake ()
    {
        list = new List<GameObject>();
    }

	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DestroyList();
        }
	}

    //TODO
    // make explosiveBoost 
    // give player limited explosions

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            if (!list.Contains(other.gameObject))
            {
                list.Add(other.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            if (list.Contains(other.gameObject))
            {
                list.Remove(other.gameObject);
            }
        }
    }

    void DestroyList()
    {
        foreach (GameObject x in list)
        {
            if (x != null)
            {
                destroyedExplosion = Instantiate(prefabExplosion, new Vector3(x.transform.position.x, x.transform.position.y + 1, x.transform.position.z), Quaternion.Euler(90, 0, 0));
                Destroy(x);
                Destroy(destroyedExplosion,1);
            } 
        }
    }
}
