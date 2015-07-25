using UnityEngine;
using System.Collections;

public class EnemyBlue : MonoBehaviour {
	
	// Public
	public float moveSpeed = 5.0f; // enemy movement speed
	public float rotationSpeed = 360.0f; // enemy rotation speed
	public float lightDistance = 6.0f; // max distance from a light source that the enemy will react
	public float noiseDistance = 10.0f; // max distance from a noise that the enemy will react
	public float noiseThreshold = 10.0f; // how loud the noise needs to be for the enemy to react
	public float rangeBetween = 0.5f; // the distance between the noise source point and the position that the enemy will stop
	
	
	// Private
	//private bool heardNoise = false; // check if enemy heard the noise
	private GameObject player; // game object for holding instance of player position
	private float loudness; // holds loudness value from mic input
	private MicControlC mic; // holds instance of MicControlC script
	private Vector3 playerPosition; // holds player position
	private Vector3 enemyPosition; // holds enemy position
	private Vector3 noiseSource; // holds last know position of player
	private float noiseSourceDistance; // holds distance between noise source and current enemy position
	private float currentDistance; // holds distance between current position of player and current enemy position
	private Quaternion targetRotation; // holds the position the enemy must rotate to face the player.
	
	
	// Use this for initialization
	void Start () {
		
		// Targets the player's position
		player = GameObject.FindWithTag("Player");
		// Gets an instance of the MicControlC script from the target variable
		mic = player.GetComponent<MicControlC> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// Get enemy position, player position and the distance between them
		enemyPosition = new Vector3 (transform.position.x, 0, transform.position.z);
		playerPosition = new Vector3 (player.transform.position.x, 0, player.transform.position.z);
		currentDistance = Vector3.Distance (enemyPosition, playerPosition);
		
		loudness = mic.loudness;// Update loudness
		
		// If light is on and enemy is within range enemy will react
		if (LightSource.lightState == true && currentDistance < lightDistance){
			// Disable noiseSource
			noiseSourceDistance = noiseDistance+1;
			// If enemy hasn't reached player position yet
			if (currentDistance > rangeBetween)
				MoveToPlayer ();
		}
		
		// If a noise is made above the threshold and enemy is in range enemy will react
		if (loudness > noiseThreshold && currentDistance < noiseDistance){
			// Set opposite direction and distance
			noiseSource = playerPosition;
			noiseSourceDistance = Vector3.Distance (noiseSource, transform.position);
		}
		// If enemy hasn't reached player position yet
		if (noiseDistance > noiseSourceDistance)
			MoveAwayFromPlayer ();
	}
	
	void MoveToPlayer () {
		
		// Rotate enemy towards player
		targetRotation = Quaternion.LookRotation (playerPosition - enemyPosition);
		transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
		
		// move towards player
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		//transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveSpeed * Time.deltaTime);
		
	}
	
	
	// Enemy reaction to microphone
	void MoveAwayFromPlayer () {
		
		// Rotate enemy towards point
		targetRotation = Quaternion.LookRotation (-(noiseSource - enemyPosition));
		transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
		
		// move towards player
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		//transform.position = Vector3.MoveTowards(transform.position, noiseSource, moveSpeed * Time.deltaTime);
		
		noiseSourceDistance = Vector3.Distance (noiseSource, transform.position);
	}
}
