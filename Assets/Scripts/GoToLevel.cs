using UnityEngine;
using System.Collections;

public class GoToLevel : MonoBehaviour {

	public string level;
	public float distance;
	
	private GameObject player; // game object for holding instance of player position

	
	// Use this for initialization
	void Start () {
		
		player = GameObject.FindWithTag("Player");

		GameManager.dungeonTimer = 0;
		GameManager.libraryTimer = 0;
		GameManager.diningHallTimer = 0;
		GameManager.laboratoryTimer = 0;
		GameManager.throneRoomTimer = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Vector3.Distance(transform.position, player.transform.position) < distance){
			AutoFade.LoadLevel(level, 1, 1, Color.black);
			//Application.LoadLevel(level);
		}
	}
}