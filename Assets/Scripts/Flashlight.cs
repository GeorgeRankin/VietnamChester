using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Flashlight : VRTK_InteractableObject {

	bool switchedOn;

	void Start(){
		
	}

	public override void StartUsing(GameObject usingObject){
		base.StartUsing (usingObject);
	}
}