using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	// Private
	private Transform target; // to keep track of the player
	private Vector3 cameraTarget; // to keep the camera pointed directly at the player

	// Use this for initialization
	void Start () {
	
		// Sets target as player and points camera to player
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		cameraTarget = new Vector3 (target.position.x, transform.position.y, target.position.z);
	}
	
	// Update is called once per frame
	void Update () {

		if (target == null)
		{
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		}
	
		// camera remains targeted on the player as they move
		cameraTarget = new Vector3 (target.position.x, transform.position.y, target.position.z);
		transform.position = Vector3.Lerp (transform.position, cameraTarget, Time.deltaTime * 8);

		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
