using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_Controller : MonoBehaviour
{ 
	GameObject Hand;
	GameObject Player;
	float rotationValue;
	float rotationInput;
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
		rotationInput = Input.GetAxis("Xbox Right Joystick Horizontal") + OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).x;
		movementInputx = Input.GetAxis("Horizontal") + OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch).x;
		movementInputy = Input.GetAxis("Vertical") + OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch).y;
		if (movementInputx != 0 || movementInputy != 0)
		{
			print("X Movement: "+Mathf.Clamp(-1 * movementInputx, -0.07f, 0.07f));
			print("Y Movement: "+Mathf.Clamp(-1 * movementInputy, -0.07f, 0.07f));
			var playerMovement = new Vector3(Mathf.Clamp(movementInputx, -0.07f, 0.07f), 0, Mathf.Clamp(movementInputy, -0.07f, 0.07f));
			Player.transform.Translate(playerMovement,Space.Self);
		}
		if (rotationInput != 0)
		{
			rotationValue += rotationInput * 0.75f;
			print(rotationValue);
			Player.transform.rotation = Quaternion.Euler(new Vector3(0, rotationValue, 0));
		}
	}
}
