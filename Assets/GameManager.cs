using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject camera;
	public GameObject environment;
	public GameObject window;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (camera.transform.position.z > window.transform.position.z) {

			environment.gameObject.SetActive (true);
		}
	}
}
