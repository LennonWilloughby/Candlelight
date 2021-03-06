﻿using UnityEngine;
using System.Collections;

public class AIGhost : MonoBehaviour {
	
	// Public
	public float lightDistance = 16.0f; // max distance from a light source that the enemy will react
	public float noiseDistance = 10.0f; // max distance from a noise that the enemy will react
	public float noiseThreshold = 10.0f; // how loud the noise needs to be for the enemy to react
	public float rangeBetween = 0.5f; // the distance between the noise source point and the position that the enemy will stop
	public float deathRange = 1.0f; // the range in which the player will die
	
	
	// Private
	private float moveSpeed = 6.0f; // enemy movement speed
	private float rotationSpeed = 360.0f; // enemy rotation speed
	private GameObject player; // game object for holding instance of player position
	private float loudness; // holds loudness value from mic input
	private MicControlC mic; // holds instance of MicControlC script
	private PlayerControl control; // holds instance of PlayerControl script
	private Vector3 playerPosition; // holds player position
	private Vector3 enemyPosition; // holds enemy position
	private Vector3 noiseSource; // holds last know position of player
	private float noiseSourceDistance; // holds distance between last known position of player and current enemy position
	private float currentDistance; // holds distance between current position of player and current enemy position
	private Quaternion targetRotation; // holds the position the enemy must rotate to face the player.
	
	
	// Use this for initialization
	void Start () {
		
		// Targets the player's position
		player = GameObject.FindWithTag("Player");
		// Gets an instance of the MicControlC script from the target variable
		mic = player.GetComponent<MicControlC> ();
		// Gets an instance of the PlayerControl script from the target variable
		control = player.GetComponent<PlayerControl> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if(GameManager.micOn){
			Listen();
		}
		else if (!GameManager.micOn) {
			Feel();
		}
		
		// Get enemy position, player position and the distance between them
		enemyPosition = new Vector3 (transform.position.x, 0, transform.position.z);
		playerPosition = new Vector3 (player.transform.position.x, 0, player.transform.position.z);
		currentDistance = Vector3.Distance (enemyPosition, playerPosition);
		
		loudness = mic.loudness;// Update loudness
		
		// If light is on and enemy is within range enemy will react
		if (LightSource.lightState == true && currentDistance < lightDistance){
			// Disable noiseSource
			noiseSourceDistance = 0;
			// If enemy hasn't reached player position yet
			if (currentDistance > rangeBetween)
				MoveToPlayer ();
		}

		// If player is in range of ghost death by ghost
		if (currentDistance < deathRange){
			player.GetComponent<DeathOnCollide>().deathByGhost = true;
		}

	}

	// If mic on Listen (check microphone input)
	void Listen () {

		// If a noise is made above the threshold and enemy is in range enemy will react
		if (loudness > noiseThreshold && currentDistance < noiseDistance){
			// Set last known position
			noiseSource = playerPosition;
			noiseSourceDistance = Vector3.Distance (noiseSource, transform.position);
		}
		// If enemy hasn't reached player position yet
		if (noiseSourceDistance > rangeBetween)
			MoveToNoiseSource ();
	}

	// If mic off Feel (check mouse right clicks)
	void Feel() {
		if (control.vibration && currentDistance < noiseDistance) {
			// Set last known position
			noiseSource = playerPosition;
			noiseSourceDistance = Vector3.Distance (noiseSource, transform.position);
		}
		// If enemy hasn't reached player position yet
		if (noiseSourceDistance > rangeBetween)
			MoveToNoiseSource ();
	}

	// Enemy Move
	void MoveToPlayer () {
		
		// Rotate enemy towards player
		targetRotation = Quaternion.LookRotation (playerPosition - enemyPosition);
		transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
		
		// move towards player
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		//transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveSpeed * Time.deltaTime);
	}
	
	// Enemy moves away from player
	void MoveAwayFromPlayer () {
		
		// Rotate enemy towards point
		targetRotation = Quaternion.LookRotation (-(playerPosition - enemyPosition));
		transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
		
		// move towards player
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		//transform.position = Vector3.MoveTowards(transform.position, noiseSource, moveSpeed * Time.deltaTime);
		
	}
	
	
	// Enemy reaction to microphone
	void MoveToNoiseSource () {
		
		// Rotate enemy towards point
		targetRotation = Quaternion.LookRotation (noiseSource - enemyPosition);
		transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
		
		// move towards player
		transform.position += transform.forward * moveSpeed * Time.deltaTime;

		// Update noise source distance
		noiseSourceDistance = Vector3.Distance (noiseSource, transform.position);
	}
}
