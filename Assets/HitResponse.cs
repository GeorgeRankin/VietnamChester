using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitResponse : MonoBehaviour {

	GameObject[] Enemies;
	int health = 3;

	void OnTriggerEnter(Collider col){
		if (col.tag == "Enemy") {
			Destroy (col.gameObject);
			Debug.Log ("overlap");
			//do something
			health --;
			if (health <= 0) {
				Enemies = GameObject.FindGameObjectsWithTag ("Enemy");
				for (int i = 0; i < Enemies.Length; i++) {
					Destroy (Enemies [i].gameObject);
					GameObject.Find ("GameManager").GetComponent<GameManager> ().GameOver = true;
				}
				//SceneManager.LoadScene("021_Controller_GrabbingObjectsWithJoints");
			}
		}
	}
}
