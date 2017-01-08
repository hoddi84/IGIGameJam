using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBoost : MonoBehaviour
{

    public float speed;
    private Controller controller;

    private ExploderController whiteExploController;
    private ExploderController blackExploController;

    private AudioController audioController;

    // Use this for initialization
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<Controller>();

        whiteExploController = GameObject.Find("WhitePlayer").GetComponent<ExploderController>();
        blackExploController = GameObject.Find("BlackPlayer").GetComponent<ExploderController>();

        audioController = GameObject.Find("AudioClips").GetComponent<AudioController>();
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
            audioController.PlayPowerUp();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "WhitePlayer" && !controller.ControlingWhite())
        {
            whiteExploController.ReduceExplosions();
            blackExploController.ReduceExplosions();
            audioController.PlayBadPowerUp();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "BlackPlayer" && !controller.ControlingWhite())
        {
            blackExploController.PickUpExplosion();
            audioController.PlayPowerUp();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "BlackPlayer" && controller.ControlingWhite())
        {
            whiteExploController.ReduceExplosions();
            blackExploController.ReduceExplosions();
            audioController.PlayBadPowerUp();
            Destroy(gameObject);
        }
    }
}
