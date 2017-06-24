using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Flashlight : VRTK_InteractableObject {

	bool switchedOn;
	Light light;

	void Start(){
		light = GetComponentInChildren<Light> ();
	}

	public override void StartUsing(GameObject usingObject){
		base.StartUsing (usingObject);
		toggleLight ();
	}

	void toggleLight(){

		if (!switchedOn) {

		}

		else if (switchedOn) {
			
		}
	}
}