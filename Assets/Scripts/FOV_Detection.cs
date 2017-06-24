using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV_Detection : MonoBehaviour {

	public GameObject InvisibleMesh;
	public GameObject TriggerMesh;

	/*
	void OnTriggerEnter(Collider col){
		if (col.tag == "Prop") {
			col.gameObject.GetComponent<Renderer> ().enabled = false;
			Debug.Log ("hit");
		}
		//col.gameObject.SetActive(false);
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Prop") {
			col.gameObject.GetComponent<Renderer> ().enabled = true;
			Debug.Log ("leave");
		}

	}
*/
	void OnTriggerEnter(Collider col){
		if (col.gameObject == TriggerMesh) {
			InvisibleMesh.GetComponent<Renderer> ().enabled = true;
		}
	}

	public bool IsInFOV(Vector3 position){

		Vector3 screenPoint = Camera.main.WorldToViewportPoint (position);
		if (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1) {
			return true;
		} else
			return false;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
