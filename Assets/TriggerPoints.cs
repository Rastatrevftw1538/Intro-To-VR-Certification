using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoints : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Points")
        {
            Debug.Log("Score!" + " " + other.name);
            other.GetComponent<Joystick_Controller>().EnteredLoop = true;
            other.GetComponent<Joystick_Controller>().LoopEntered = other.gameObject;

        }
    }

   }
