using UnityEngine;
using System.Collections;

public class LevelCompleteSpotlight : MonoBehaviour {

	public string levelComplete;

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetInt(levelComplete) == 1) {
			light.enabled = true;
		}
		else {
			light.enabled = false;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
