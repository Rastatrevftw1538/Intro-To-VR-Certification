using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Points = 0;
    [SerializeField] private TMP_Text pointUI;
    public GameObject Player;
    private GameObject Drone;
    private Joystick_Controller DroneControls;
    public GameObject PointHoopPrefab;
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
            Instantiate(PointHoopPrefab, new Vector3(Random.Range(-12, 15), Random.Range(5, 12), Random.Range(-(Mathf.Abs(DroneControls.LoopEntered.transform.position.z) + 1), -(Mathf.Abs(DroneControls.LoopEntered.transform.position.z) + 20))), new Quaternion(0, 0, 0, 0)); 
            Destroy(DroneControls.LoopEntered);
            DroneControls.EnteredLoop = false;
            Points += 1;
        }
    }
}
