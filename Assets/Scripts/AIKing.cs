using UnityEngine;
using System.Collections;

public class AIKing : MonoBehaviour {
	
	// Public
	public int health = 5; // the amount of times the enemy must be damaged to be beaten
	public float senseDistance = 20.0f; // max distance from player that the enemy will react
	public float lightDistance = 20.0f; // max distance from a light source that the enemy will react
	public float rangeBetween = 0.5f; // the distance between the noise source point and the position that the enemy will stop
	public float deathRange = 1.0f; // the range in which the player will die
	public bool trapped = false; // if the king is trapped in a firepit
	public bool update = true; // if the king is trapped in a firepit
	public float trappedDistance = 2.0f; // dictance in which king can be trapped


	// Private
	public float moveSpeed = 4.5f; // enemy movement speed
	private float newMoveSpeed = 4.5f; // new enemy movement speed
	private float speedUp = 0.5f; // amount of speed enemy will gain upon being damaged
	private float rotationSpeed = 360.0f; // enemy rotation speed
	private GameObject player; // game object for holding instance of player position
	private Vector3 playerPosition; // holds player position
	private Vector3 enemyPosition; // holds enemy position
	private float currentDistance; // holds distance between current position of player and current enemy position
	private Quaternion targetRotation; // holds the position the enemy must rotate to face the player.


	// variables for firepits
	private GameObject firepit1;
	private GameObject firepit2;
	private GameObject firepit3;
	private GameObject firepit4;
	private GameObject firepit5;
	private GameObject firepit6;

	private Vector3 firepitPosition1;
	private Vector3 firepitPosition2;
	private Vector3 firepitPosition3;
	private Vector3 firepitPosition4;
	private Vector3 firepitPosition5;
	private Vector3 firepitPosition6;

	private float firepitDistance1;
	private float firepitDistance2;
	private float firepitDistance3;
	private float firepitDistance4;
	private float firepitDistance5;
	private float firepitDistance6;
	

	
	// Use this for initialization
	void Start () {

		// Targets the player's position
		player = GameObject.FindWithTag("Player");

		// Finds and calculates firepit positions
		firepit1 = GameObject.Find("FirepitEthereal1");
		firepit2 = GameObject.Find("FirepitEthereal2");
		firepit3 = GameObject.Find("FirepitEthereal3");
		firepit4 = GameObject.Find("FirepitEthereal4");
		firepit5 = GameObject.Find("FirepitEthereal5");
		firepit6 = GameObject.Find("FirepitEthereal6");

		firepitPosition1 = new Vector3 (firepit1.transform.position.x, 0, firepit1.transform.position.z);
		firepitPosition2 = new Vector3 (firepit2.transform.position.x, 0, firepit2.transform.position.z);
		firepitPosition3 = new Vector3 (firepit3.transform.position.x, 0, firepit3.transform.position.z);
		firepitPosition4 = new Vector3 (firepit4.transform.position.x, 0, firepit4.transform.position.z);
		firepitPosition5 = new Vector3 (firepit5.transform.position.x, 0, firepit5.transform.position.z);
		firepitPosition6 = new Vector3 (firepit6.transform.position.x, 0, firepit6.transform.position.z);
		
	}
	
	// Update is called once per frame
	void Update () {

		// Get enemy position, player position and the distance between them
		enemyPosition = new Vector3 (transform.position.x, 0, transform.position.z);
		playerPosition = new Vector3 (player.transform.position.x, 0, player.transform.position.z);
		currentDistance = Vector3.Distance (enemyPosition, playerPosition);

		// As long as the firepit hasn't been destroyed yet get the distance between it and the enemy
		// Otherwise make the distance too great for the king to be trapped
		if (firepit1 != null)
			firepitDistance1 = Vector3.Distance (firepitPosition1, enemyPosition);
		else
			firepitDistance1 = 20.0f;
		if (firepit2 != null)
			firepitDistance2 = Vector3.Distance (firepitPosition2, enemyPosition);
		else
			firepitDistance2 = 20.0f;
		if (firepit3 != null)
			firepitDistance3 = Vector3.Distance (firepitPosition3, enemyPosition);
		else
			firepitDistance3 = 20.0f;
		if (firepit4 != null)
			firepitDistance4 = Vector3.Distance (firepitPosition4, enemyPosition);
		else
			firepitDistance4 = 20.0f;
		if (firepit5 != null)
			firepitDistance5 = Vector3.Distance (firepitPosition5, enemyPosition);
		else
			firepitDistance5 = 20.0f;
		if (firepit6 != null)
			firepitDistance6 = Vector3.Distance (firepitPosition6, enemyPosition);
		else
			firepitDistance6 = 20.0f;


		if (currentDistance < deathRange){
			player.GetComponent<DeathOnCollide>().deathByGhost = true;
		}

		// If enemy is within range enemy will react
		if (currentDistance < senseDistance){
			// If enemy hasn't reached player position yet
			if (currentDistance > rangeBetween)
				MoveToPlayer ();
		}

		// If light is on and enemy is within range enemy will react
		if (LightSource.lightState == true && currentDistance < lightDistance){
			// If enemy hasn't reached player position yet
			if (currentDistance > rangeBetween)
				MoveToPlayer();
		}

		// If light source on check trap distance then trap
		if (LightSource.lightState == true && firepitDistance1 < trappedDistance)
			trapped = true;
		if (LightSource.lightState == true && firepitDistance2 < trappedDistance)
			trapped = true;
		if (LightSource.lightState == true && firepitDistance3 < trappedDistance)
			trapped = true;
		if (LightSource.lightState == true && firepitDistance4 < trappedDistance)
			trapped = true;
		if (LightSource.lightState == true && firepitDistance5 < trappedDistance)
			trapped = true;
		if (LightSource.lightState == true && firepitDistance6 < trappedDistance)
			trapped = true;

		// If trapped set new move speed to one unit faster, set current move speed to 0 for the duration of trap and take one health
		if (trapped){
			if (update){
				newMoveSpeed = moveSpeed + speedUp;
				health = health - 1;
				update = false;
			}
			moveSpeed = 0;

		}
		// When out of trap set kings move speed to 
		else {
			moveSpeed = newMoveSpeed;
			update = true;
		}

		// If no health king has died, set speed to 0 so that king can't kill player, set level complete, go to main menu
		if (health == 0){
			moveSpeed = 0;
			newMoveSpeed = 0;
			PlayerPrefs.SetInt("throneRoomComplete", 1);
			PlayerPrefs.Save();
			AutoFade.LoadLevel("MenuMain", 5, 2, Color.white);
		}

		trapped = false;
		
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
}