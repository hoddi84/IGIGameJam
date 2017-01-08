using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBoost : MonoBehaviour
{

    public float speed;
    private Controller controller;

    private ExploderController whiteExploController;
    private ExploderController blackExploController;

    // Use this for initialization
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<Controller>();

        whiteExploController = GameObject.Find("WhitePlayer").GetComponent<ExploderController>();
        blackExploController = GameObject.Find("BlackPlayer").GetComponent<ExploderController>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 1 * speed, 0, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WhitePlayer" && controller.ControlingWhite())
        {
            whiteExploController.PickUpExplosion();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "WhitePlayer" && !controller.ControlingWhite())
        {
            whiteExploController.ReduceExplosions();
            blackExploController.ReduceExplosions();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "BlackPlayer" && !controller.ControlingWhite())
        {
            blackExploController.PickUpExplosion();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "BlackPlayer" && controller.ControlingWhite())
        {
            whiteExploController.ReduceExplosions();
            blackExploController.ReduceExplosions();
            Destroy(gameObject);
        }
    }
}
