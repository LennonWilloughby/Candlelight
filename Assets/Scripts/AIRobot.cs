using UnityEngine;
using System.Collections;

public class AIRobot : MonoBehaviour {
	
	// Public
	public float senseDistance = 20.0f; // max distance from player that the enemy will react
	public float rangeBetween = 0.5f; // the distance between the noise source point and the position that the enemy will stop
	
	
	// Private
	private float moveSpeed = 5.0f; // enemy movement speed
	private float rotationSpeed = 90.0f; // enemy rotation speed
	private GameObject player; // game object for holding instance of player position
	private Vector3 playerPosition; // holds player position
	private Vector3 enemyPosition; // holds enemy position
	private float currentDistance; // holds distance between current position of player and current enemy position
	private Quaternion targetRotation; // holds the position the enemy must rotate to face the player.
	
	
	// Use this for initialization
	void Start () {
		
		// Targets the player's position
		player = GameObject.FindWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// Get enemy position, player position and the distance between them
		enemyPosition = new Vector3 (transform.position.x, 0, transform.position.z);
		playerPosition = new Vector3 (player.transform.position.x, 0, player.transform.position.z);
		currentDistance = Vector3.Distance (enemyPosition, playerPosition);

		
		// If enemy is within range enemy will react
		if (currentDistance < senseDistance){
			// If enemy hasn't reached player position yet
			if (currentDistance > rangeBetween)
				MoveToPlayer ();
		}
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
}
