using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject mcamera;
	public GameObject environment;
	public GameObject window;
	public GameObject SpawnerPrefab;
	public Transform[] SpawnPositions;
	public TextMesh Score;
	private bool spawnersActivated;
	private bool notSame;
	private float Timer;
	private bool spawned;
	int i;
	int j;

	// Update is called once per frame
	void Update () {
		if (spawnersActivated) {
			Timer += Time.deltaTime;
			Score.GetComponent<MeshRenderer> ().enabled = true;
			Score.text = Timer.ToString("#.");
			if (Timer >= 15) {
				Spawn ();
			}
		}
		/*
		if (mcamera.transform.position.z > window.transform.position.z) {
			environment.gameObject.SetActive (true);
		}
		*/
	}

	void Spawn(){
		if (!spawned) {
			if (i != 0 && j != 0)
			Instantiate (SpawnerPrefab, SpawnPositions [0].transform.position, SpawnPositions [0].transform.rotation);
			if (i != 1 && j != 1)
			Instantiate (SpawnerPrefab, SpawnPositions [1].transform.position, SpawnPositions [1].transform.rotation);
			if (i != 2 && j != 2)
			Instantiate (SpawnerPrefab, SpawnPositions [2].transform.position, SpawnPositions [2].transform.rotation);
			if (i != 3 && j != 3)
			Instantiate (SpawnerPrefab, SpawnPositions [3].transform.position, SpawnPositions [3].transform.rotation);
			if (i != 4 && j != 4)
			Instantiate (SpawnerPrefab, SpawnPositions [4].transform.position, SpawnPositions [4].transform.rotation);
			if (i != 5 && j != 5)
			Instantiate (SpawnerPrefab, SpawnPositions [5].transform.position, SpawnPositions [5].transform.rotation);
			spawned = true;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Prop") {
			Debug.Log ("starting");
			if (!spawnersActivated) {
				i = Random.Range(0,6);
				while (notSame) {
					j = Random.Range (0, 6);
					if (i == j) {
						j = Random.Range (0, 6);
					} else
						notSame = true;
				}	
				Instantiate (SpawnerPrefab, SpawnPositions [i].transform.position, SpawnPositions [i].transform.rotation);
				Instantiate (SpawnerPrefab, SpawnPositions [j].transform.position, SpawnPositions [j].transform.rotation);
				spawnersActivated = true;
			}
		}
	}
}
