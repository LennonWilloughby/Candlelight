using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {

	private bool paused = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyUp("p")) {
			if (paused) {
				Time.timeScale = 1.0f;
				paused = false;
			}
			else if (!paused) {
				Time.timeScale = 0.0f;
				paused = true;
			}
		}

		if (Input.GetKeyUp("m")) {

			AutoFade.LoadLevel ("MenuMain", 1, 1, Color.black);
			//Application.LoadLevel ("MainMenu");
		}

	}
}
