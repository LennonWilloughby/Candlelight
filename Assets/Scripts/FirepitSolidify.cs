using UnityEngine;
using System.Collections;

public class FirepitSolidify : MonoBehaviour {


	public float lightDistance = 6.0f;
	public float trappedDistance = 3.0f;

	private GameObject player;
	private Vector3 playerPosition;
	private Vector3 firepitPosition;
	private float currentDistance;
	private bool destroyable = false;

	private float fullAlpha = 1.0f;
	private float halfAlpha = 0.3f;


	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

		firepitPosition = new Vector3 (transform.position.x, 0, transform.position.z);
		playerPosition = new Vector3 (player.transform.position.x, 0, player.transform.position.z);
		currentDistance = Vector3.Distance (firepitPosition, playerPosition);

		if (LightSource.lightState == true && currentDistance < lightDistance){
			foreach (Transform child in transform){
				if(child.gameObject.collider){
					child.gameObject.collider.enabled = true;
				}
				Color color = child.renderer.material.color;
				color.a = fullAlpha;

				child.renderer.material.color = color;
			}
			destroyable = true;
		}
		else{
			foreach (Transform child in transform){
				if(child.gameObject.collider){
					child.gameObject.collider.enabled = false;
				}
				Color color = child.renderer.material.color;
				color.a = halfAlpha;
				
				child.renderer.material.color = color;
			}
			if(destroyable){
				Destroy(gameObject);
			}
		}
	}
}
