using UnityEngine;
using System.Collections;

public class GoToNextLevel : MonoBehaviour {

	private GameObject player; // game object for holding instance of player position
	private float distance = 3.0f;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Vector3.Distance(transform.position, player.transform.position) < distance){
			int nextLevel = Application.loadedLevel + 1;
			AutoFade.LoadLevel(nextLevel, 1, 1, Color.black);
			//Application.LoadLevel(nextLevel);
		}
	}
}
