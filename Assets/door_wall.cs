using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_wall : MonoBehaviour {

	bool FOV_Overlap;
	float timer;

	bool done = false;
	public GameObject BlankWall;
	
	// Update is called once per frame
	void Update () {

		if (FOV_Overlap) {
			timer += Time.deltaTime;
		}
		if (timer > 20) {
			done = true;
		}
		if (done && !FOV_Overlap) {
			
			// disable this wall, activate wall_no_door.
			this.gameObject.SetActive(false);
			BlankWall.gameObject.SetActive (true);
		}
	}

	void OnTriggerEnter (Collider col){

		if (col.tag == "FOV") {
			FOV_Overlap = true;
		}
	}

	void OnTriggerExit(Collider col){

		if (col.tag == "FOV"){
			FOV_Overlap = false;
		}
	}
}