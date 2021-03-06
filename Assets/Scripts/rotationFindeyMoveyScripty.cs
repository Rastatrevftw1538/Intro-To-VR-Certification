using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationFindeyMoveyScripty : MonoBehaviour
{
	GameObject Hand;
	GameObject Player;
	float rotationValue;
	float rotationInput;
	// Start is called before the first frame update
	void Start()
    {
		Player = this.transform.parent.parent.parent.gameObject;
		Hand = this.gameObject;

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		rotationInput = Input.GetAxis("Horizontal") + OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
		if ((Input.GetAxis("Xbox Right Trigger") > 0 )|| OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
		{
		print(Mathf.Clamp(-1 * Hand.transform.rotation.x, -0.07f, 0.07f));
			var playerMovement = new Vector3(Mathf.Clamp(-1*Hand.transform.rotation.z, -0.07f, 0.07f), 0, Mathf.Clamp(Hand.transform.rotation.x, -0.07f, 0.07f));
			Player.transform.Translate(playerMovement,Space.Self);
		}
		if (rotationInput != 0){
			rotationValue += rotationInput*2;
			print(rotationValue);
			Player.transform.rotation = Quaternion.Euler(new Vector3(0, rotationValue, 0));
		}
	}
}
