using UnityEngine;
using System.Collections;

public class MicrophoneOn : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {

		GameManager.micOn = true;

	}
}
