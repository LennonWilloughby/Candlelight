using UnityEngine;
using System.Collections;

public class EnableFinalDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetInt("dungeonComplete") == 1 && PlayerPrefs.GetInt("libraryComplete") == 1 && PlayerPrefs.GetInt("diningHallComplete") == 1 && PlayerPrefs.GetInt("laboratoryComplete") == 1){

			gameObject.GetComponent<GoToLevel>().enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
