using UnityEngine;
using System.Collections;

public class MicrophoneOffLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!GameManager.micOn) {
			light.enabled = true;
		}
		else {
			light.enabled = false;
		}
	
	}
}
