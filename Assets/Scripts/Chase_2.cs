using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase_2 : MonoBehaviour {

	private GameObject player;
	private Vector3 direction;
	private bool Overlap;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Camera (eye)");
	}

	void OnTriggerEnter (Collider col){
		if (col.tag == "FOV")
			Overlap = true;
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "FOV") {
			Overlap = false;
		}
	}

	// Update is called once per frame
	void Update () {

		if (Overlap == false) {
			direction = player.transform.position - this.transform.position;
			//direction.y = 0;

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
			this.transform.position = Vector3.MoveTowards (transform.position, player.transform.position, Time.deltaTime / 0.5f);
		}
	}

}
