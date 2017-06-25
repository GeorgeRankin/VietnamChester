﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

	public Spawner spawner;
	private float speed;

	private GameObject player;
	private Vector3 direction;
	public bool FOV_Overlap;
	private bool Flashlight_Overlap;
	public bool killed;
	public int Burn;
	public float counter;

	// Use this for initialization
	void Start () {
		Debug.Log (counter);
		GetComponent<AudioSource> ().Play();
		player = GameObject.Find ("Camera (eye)");
		if (counter <=30f)
		speed = Random.Range (4, 6);
		else if (counter <= 60f){
			speed = Random.Range (2, 3);
		}
		else{
			speed = Random.Range (1, 2);
		}
	}

	void OnTriggerEnter (Collider col){
		if (col.tag == "FOV")
			FOV_Overlap = true;
		
		if (col.tag == "Flashlight")
			Flashlight_Overlap = true;
	}

	void OnTriggerExit(Collider col){
		
		if (col.tag == "FOV"){
			FOV_Overlap = false;
			Burn = 0;
		}
		
		if (col.tag == "Flashlight"){
			Flashlight_Overlap = false;
			Burn = 0;
		}
	}

	// Update is called once per frame
	void Update () {
		
		if (!killed) {
			if (FOV_Overlap && Flashlight_Overlap) {
				this.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				Burn++;

				if (Burn == 50) {
					killed = true;
					GetComponent<Rigidbody> ().isKinematic = false;
				}

			} else if (FOV_Overlap == false) {
				
				direction = player.transform.position - this.transform.position;
				this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 3.0f);
				this.transform.position = Vector3.MoveTowards (transform.position, player.transform.position, Time.deltaTime / speed);

			} else
				this.gameObject.GetComponent<Renderer> ().material.color = Color.white;
		}
	}
}