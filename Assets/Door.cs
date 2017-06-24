using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public void OpenDoor(){
		
		transform.Rotate (0, 0, 30);
	}

	public void CloseDoor(){

		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, -30), Time.deltaTime * 5);
	}
}