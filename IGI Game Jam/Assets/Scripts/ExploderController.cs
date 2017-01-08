using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderController : MonoBehaviour {

    private List<GameObject> list;
    private int amountOfExplosions;
    public GameObject prefabExplosion;
    private GameObject destroyedExplosion;
    private AudioController audioController;

	// Use this for initialization
    void Awake ()
    {
        list = new List<GameObject>();
        amountOfExplosions = 0;
        audioController = GameObject.Find("AudioClips").GetComponent<AudioController>();
    }

	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Q) && amountOfExplosions > 0)
        {
            DestroyList();
            audioController.PlayExplosion();
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
        amountOfExplosions -= 1;
    }

    public void PickUpExplosion()
    {
        amountOfExplosions++;
    }

    public void ReduceExplosions()
    {
        amountOfExplosions--;
        if (amountOfExplosions < 0)
        {
            amountOfExplosions = 0;
        }
    }

    public int GetExplosionAmount()
    {
        return amountOfExplosions;
    }
}
