using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	public bool showNote = false;
	public float pickupDistance = 3.0f;
	public Texture noteTexture;

	private GameObject player;
	private Vector3 playerPosition;
	private float currentDistance;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {

		playerPosition = new Vector3 (player.transform.position.x, 0, player.transform.position.z);
		currentDistance = Vector3.Distance (transform.position, playerPosition);


		if (showNote && Input.GetMouseButtonDown(0)) {
			showNote = false;
		}
	
	}

	void OnMouseUp() {

		if (currentDistance < pickupDistance) {
			showNote = true;
		}
	}

	void OnGUI() {

		if (showNote){

			GUI.DrawTexture(new Rect(Screen.width/8, Screen.height/8, Screen.width - Screen.width/4, Screen.height - Screen.height/4), noteTexture, ScaleMode.StretchToFill, true, 10.0F);
		}
	}
}
