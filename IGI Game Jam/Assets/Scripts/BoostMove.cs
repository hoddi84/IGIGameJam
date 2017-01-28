using UnityEngine;
using System.Collections;

public class BoostMove : MonoBehaviour
{
    public float leftPosition;
    public float rightPosition;

   // private static BoostMove thisObject;

    private Vector3 pos1;
    private Vector3 pos2;

    public float speed = 1.0f;


void Start()
    {
     // thisObject = GameObject.Find("TimeBoost").GetComponent<BoostMove>();
      pos1 = new Vector3(leftPosition, transform.position.y, transform.position.z);
      pos2 = new Vector3(rightPosition, transform.position.y, transform.position.z);
} 

void Update()
    {

        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }

}