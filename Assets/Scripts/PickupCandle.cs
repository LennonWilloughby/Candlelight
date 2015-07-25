using UnityEngine;
using System.Collections;

public class PickupCandle : MonoBehaviour {
	
	public float pickupDistance = 1.0f;

	private GameObject candle;

	
	void Start()
	{
		candle = GameObject.FindWithTag("Pickup Candle");
		gameObject.GetComponent<LightSource>().enabled = false;
	}

	void Update ()
	{
		if (Vector3.Distance(transform.position, candle.transform.position) < pickupDistance){

			gameObject.GetComponent<HowToLight>().enabled = true;
			gameObject.GetComponent<LightSource>().enabled = true;
			Destroy(candle);
			gameObject.GetComponent<PickupCandle>().enabled = false;
		}
	}

}