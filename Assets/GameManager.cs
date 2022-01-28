using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Points = 0;
    [SerializeField] private TMP_Text pointUI;
    private GameObject Drone;
    private Joystick_Controller DroneControls;
    // Start is called before the first frame update
    void Start()
    {
        Drone = GameObject.FindWithTag("Drone");
        pointUI.text = "0";
        DroneControls = Drone.GetComponent<Joystick_Controller>();
    }
    // Update is called once per frame
    void Update()
    {
        pointUI.text = Points.ToString();
        if (DroneControls.EnteredLoop)
        {
            DroneControls.LoopEntered.SetActive(false);
            DroneControls.EnteredLoop = false;
            Points += 1;
        }
    }
}
