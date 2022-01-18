using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoints : MonoBehaviour
{
    //private GameObject Drone;
    // Start is called before the first frame update
    void Start()
    {

        //Drone = GameObject.FindWithTag("Drone");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Drone")
        {
            Debug.Log("Score!" + " " + other.name);
            other.GetComponent<Joystick_Controller>().EnteredLoop = true;
            other.GetComponent<Joystick_Controller>().LoopEntered = other.gameObject;

        }
    }

   }
