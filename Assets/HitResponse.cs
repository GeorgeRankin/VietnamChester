using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitResponse : MonoBehaviour {

	int health = 3;

	void OnTriggerEnter(Collider col){
		if (col.tag == "Enemy") {
			Destroy (col.gameObject);
			Debug.Log ("overlap");
			//do something
			health --;
			if (health <= 0) {
				SceneManager.LoadScene("021_Controller_GrabbingObjectsWithJoints");
			}
		}
	}
}
