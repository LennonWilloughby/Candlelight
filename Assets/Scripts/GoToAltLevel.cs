using UnityEngine;
using System.Collections;

public class GoToAltLevel : MonoBehaviour {

	public string level;
	public float distance;
	public AudioClip keyPickup;
	
	private GameObject player; // game object for holding instance of player position
	private bool pickupKey = false;
	
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.FindWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Vector3.Distance(transform.position, player.transform.position) < distance && pickupKey == false){
			pickupKey = true;
			AudioSource.PlayClipAtPoint (keyPickup, transform.position, 0.5f);
			AutoFade.LoadLevel(level, 1, 1, Color.white);
			//Application.LoadLevel(level);
		}
	}
}