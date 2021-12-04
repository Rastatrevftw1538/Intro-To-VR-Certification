using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public GameObject belt;
    public Transform pointToGoTo;
    public Transform endpoint;
    public Transform endpoint2;
    public float speed;

    private void Start()
    {
        pointToGoTo.position = endpoint.position;
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Vector3.Distance(other.gameObject.transform.position, pointToGoTo.position) <= 1)
        {
            if (Vector3.Distance(other.gameObject.transform.position, endpoint.position) <= 1)
            {
                pointToGoTo.position = endpoint2.position;
            }
            else if (Vector3.Distance(other.gameObject.transform.position, endpoint2.position) <= 1)
            {
                pointToGoTo.position = endpoint.position;
            }
        }
        other.transform.position = Vector3.MoveTowards(other.transform.position, pointToGoTo.position, speed * Time.deltaTime);
    }
}
