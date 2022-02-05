using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public GameObject belt;
    public Transform pointToGoTo;
    public List<Transform> endpoints = new List<Transform>();
    private int currentPointIndex = 0;
    public float speed;

    private void Start()
    {
        pointToGoTo.position = endpoints[0].position;
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Vector3.Distance(other.gameObject.transform.position, pointToGoTo.position) <= 2)
        {
            currentPointIndex += 1;
            pointToGoTo.position = endpoints[currentPointIndex].position;
        }
        other.transform.position = Vector3.MoveTowards(other.transform.position, pointToGoTo.position, speed * Time.deltaTime);
    }
}
