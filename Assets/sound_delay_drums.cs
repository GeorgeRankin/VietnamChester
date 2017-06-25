using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_delay_drums : MonoBehaviour {

	float timer;

	// Use this for initialization
	void Start () {

		timer = 0;
	}

	// Update is called once per frame
	void Update () {

		if (!GetComponent<AudioSource> ().isPlaying) {

			timer += Time.deltaTime;
			if (timer >= 60) {

				GetComponent<AudioSource> ().Play ();
				timer = 0;
			}
		}
	}
}
