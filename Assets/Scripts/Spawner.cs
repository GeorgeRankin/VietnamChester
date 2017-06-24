using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	private bool spawnFOV_Overlap;
	public GameObject Enemy;
	private GameObject SpawnedEnemy;

	// Use this for initialization
	void Start () {
		SpawnedEnemy = Instantiate (Enemy, transform.position, transform.rotation);
	}

	void Update(){
		
			// Enemy is dead?									  // Not looking at the enemy?								 // Not looking at spawner?
		if (SpawnedEnemy.GetComponent<Chase> ().killed == true && SpawnedEnemy.GetComponent<Chase>().FOV_Overlap == false && spawnFOV_Overlap == false) {
		
			Destroy (SpawnedEnemy);
			SpawnEnemy ();
		}
	}

	public void SpawnEnemy(){
		
		SpawnedEnemy = Instantiate (Enemy, transform.position, transform.rotation);
		SpawnedEnemy.GetComponent<Chase> ().spawner = this.GetComponent<Spawner>();
	}

	void OnTriggerEnter(Collider col){

		//Debug.Log ("enter spawner");
		if (col.tag == "FOV"){
			spawnFOV_Overlap = true;
		}
	}

	void OnTriggerExit(Collider col){

		//Debug.Log ("exit spawner");
		if (col.tag == "FOV"){
			spawnFOV_Overlap = false;
		}
	}
}