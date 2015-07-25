using UnityEngine;
using System.Collections;

public class ClickToLevel : MonoBehaviour {

	public string level;
	
	// Use this for initialization
	void Start () {

		GameManager.dungeonTimer = 0;
		GameManager.libraryTimer = 0;
		GameManager.diningHallTimer = 0;
		GameManager.laboratoryTimer = 0;
		GameManager.throneRoomTimer = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseUp() {
		
		AutoFade.LoadLevel (level, 1, 1, Color.black);
		//Application.LoadLevel (level);
	}
}
