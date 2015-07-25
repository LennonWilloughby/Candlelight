using UnityEngine;
using System.Collections;

public class OptionVolume : MonoBehaviour {

	private float volumeValue = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GameManager.volume = volumeValue;
	
	}


	void OnGUI() {
		
		volumeValue = GUI.HorizontalSlider(new Rect(590, 290, 210, 10), volumeValue, 0.0f, 1.0f);
		
	}
}
