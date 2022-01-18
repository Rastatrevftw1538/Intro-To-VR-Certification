using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_Controller : MonoBehaviour
{
	public bool EnteredLoop;
	public GameObject LoopEntered;

	GameObject Hand;
	GameObject Player;
	float upDownValue;
	float upDownInput;
	float movementValue;
	float movementInputx;
	float movementInputy;

	// Start is called before the first frame update
	void Start()
	{
		Player = this.gameObject;

	}

	// Update is called once per frame
	void Update()
	{
		upDownInput = Input.GetAxis("Xbox Right Joystick Vertical") + OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).x;
		movementInputx = Input.GetAxis("Horizontal") + OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch).x;
		movementInputy = Input.GetAxis("Vertical") + OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch).y;
		if (movementInputx != 0 || movementInputy != 0|| upDownInput != 0)
		{
			//print("X Movement: "+Mathf.Clamp(-1 * movementInputx, -0.07f, 0.07f));
			//print("Y Movement: "+Mathf.Clamp(-1 * movementInputy, -0.07f, 0.07f));
			//print("Z Movement: " + Mathf.Clamp(-1 * upDownInput, -0.07f, 0.07f));
			var playerMovement = new Vector3(-(Mathf.Clamp(movementInputx, -0.07f, 0.07f)) ,-(Mathf.Clamp(upDownInput, -0.07f, 0.07f)), -(Mathf.Clamp(movementInputy, -0.07f, 0.07f)));
			Player.transform.Translate(playerMovement,Space.Self);
		}
	}
	public void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Points")
		{
			Debug.Log("Score!" + " " + other.name);
			this.GetComponent<Joystick_Controller>().EnteredLoop = true;
			this.GetComponent<Joystick_Controller>().LoopEntered = other.gameObject;

		}
	}
}
