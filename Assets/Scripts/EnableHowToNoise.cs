using UnityEngine;
using System.Collections;

public class EnableHowToNoise : MonoBehaviour {

	public float enableDistance = 3.0f;

	private GameObject gate;

	// Use this for initialization
	void Start () {

		gate = GameObject.FindWithTag("Gate");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance(transform.position, gate.transform.position) < enableDistance){
			
			gameObject.GetComponent<HowToNoise>().enabled = true;
		}
	}
}
