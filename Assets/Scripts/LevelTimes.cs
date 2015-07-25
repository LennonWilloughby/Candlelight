using UnityEngine;
using System.Collections;

public class LevelTimes : MonoBehaviour {

	private float minutes = 0;
	private float seconds = 0;


	// Use this for initialization
	void Start () {

		if (gameObject.name == "Text Dungeon Time"){
			minutes = Mathf.Floor (PlayerPrefs.GetFloat("dungeonTime")/60);
			seconds = Mathf.Round (PlayerPrefs.GetFloat("dungeonTime")%60);
			GetComponent<TextMesh>().text = minutes.ToString("00") + ":" + seconds.ToString("00");
		}
		if (gameObject.name == "Text Library Time"){
			minutes = Mathf.Floor (PlayerPrefs.GetFloat("libraryTime")/60);
			seconds = Mathf.Round (PlayerPrefs.GetFloat("libraryTime")%60);
			GetComponent<TextMesh>().text = minutes.ToString("00") + ":" + seconds.ToString("00");
		}
		if (gameObject.name == "Text Dining Hall Time"){
			minutes = Mathf.Floor (PlayerPrefs.GetFloat("diningHallTime")/60);
			seconds = Mathf.Round (PlayerPrefs.GetFloat("diningHallTime")%60);
			GetComponent<TextMesh>().text = minutes.ToString("00") + ":" + seconds.ToString("00");
		}
		if (gameObject.name == "Text Laboratory Time"){
			minutes = Mathf.Floor (PlayerPrefs.GetFloat("laboratoryTime")/60);
			seconds = Mathf.Round (PlayerPrefs.GetFloat("laboratoryTime")%60);
			GetComponent<TextMesh>().text = minutes.ToString("00") + ":" + seconds.ToString("00");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
