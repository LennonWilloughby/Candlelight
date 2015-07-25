using UnityEngine;
using System.Collections;

public class MenuLight : MonoBehaviour {

	private float lightLow = 2.0f;
	private float lightHigh = 6.0f;
	public float changeSpeed = 4.0f;
	public bool hover = false;
	private float startingTime = 0;
	private float repeatingTime = 1;
	

	// Use this for initialization
	void Start () {

		startingTime = transform.position.x / 10 + transform.position.y;
		repeatingTime = transform.position.z / 10;

		light.intensity = lightHigh;
		Example ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		FadeLight ();
	}

	void Hover () {
		if (hover)
			hover = false;
		else
			hover = true;
	}

	void FadeLight () {
		
		// if mouse is hovering on collider increase light intensity
		if (hover) {
			light.intensity = Mathf.Lerp(light.intensity, lightLow, changeSpeed * Time.deltaTime);
		}
		else {
			light.intensity = Mathf.Lerp (light.intensity, lightHigh, changeSpeed * Time.deltaTime);
		}
	}

	void Example (){
		InvokeRepeating("Hover", startingTime, repeatingTime);
	}
}
