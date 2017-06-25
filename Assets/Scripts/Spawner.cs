using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	private bool spawnFOV_Overlap;
	public GameObject Enemy;
	private GameObject SpawnedEnemy;
	//private bool complete;
	//public bool spawned;
	private bool StartLoop;
	private float Timer;

	// Use this for initialization
	void Start () {
		//complete = false;
		SpawnedEnemy = Instantiate (Enemy, transform.position, transform.rotation);
		SpawnedEnemy.GetComponent<Chase> ().counter = Timer;
		//spawned = false;

	}

	void Update(){
		Timer += Time.deltaTime;
		//Debug.Log (Timer);
		/*
		Debug.Log (spawned);
		if (spawned && !StartLoop) {
			SpawnedEnemy = Instantiate (Enemy, transform.position, transform.rotation);

			StartLoop = true;
		}
*/
		//if (!complete && StartLoop) {
			// Enemy is dead?									  // Not looking at the enemy?								 // Not looking at spawner?
			if (SpawnedEnemy.GetComponent<Chase>().killed == true && SpawnedEnemy.GetComponent<Chase> ().FOV_Overlap == false && spawnFOV_Overlap == false) {
				Destroy (SpawnedEnemy);
				SpawnEnemy ();
			//}
		}
	}

	public void SpawnEnemy(){
		//yield return new WaitForSeconds(Random.Range (0, 2));
		SpawnedEnemy = Instantiate (Enemy, transform.position, transform.rotation);
		SpawnedEnemy.GetComponent<Chase> ().spawner = this.GetComponent<Spawner>();
		SpawnedEnemy.GetComponent<Chase> ().counter = Timer;
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