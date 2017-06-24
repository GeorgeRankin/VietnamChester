﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject Enemy;

	// Use this for initialization
	void Start () {
		Instantiate (Enemy, transform.position, transform.rotation);
	}

	public void SpawnEnemy(){
		GameObject SpawnedEnemy = Instantiate (Enemy, transform.position, transform.rotation);
		SpawnedEnemy.GetComponent<Chase> ().spawner = this.GetComponent<Spawner>();
	}
}
