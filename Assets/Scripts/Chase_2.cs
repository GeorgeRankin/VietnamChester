using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase_2 : MonoBehaviour {

	public Spawner spawner;

	private GameObject player;
	private Vector3 direction;
	private bool FOV_Overlap;
	private bool Flashlight_Overlap;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Camera (eye)");
	}

	void OnTriggerEnter (Collider col){
		if (col.tag == "FOV")
			FOV_Overlap = true;
		
		if (col.tag == "Flashlight")
			Flashlight_Overlap = true;
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "FOV") 
			FOV_Overlap = false;
		
		if (col.tag == "Flashlight")
			Flashlight_Overlap = false;
	}

	// Update is called once per frame
	void Update () {
		if (FOV_Overlap && Flashlight_Overlap) {
			this.gameObject.GetComponent<Renderer>().material.color = Color.red;
			//spawner.SpawnEnemy ();
			Destroy(gameObject);
		}

		else if (FOV_Overlap == false) {
			direction = player.transform.position - this.transform.position;
			//direction.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
			this.transform.position = Vector3.MoveTowards (transform.position, player.transform.position, Time.deltaTime / 2f);
		}

		else
			this.gameObject.GetComponent<Renderer>().material.color = Color.white;
	}
}
