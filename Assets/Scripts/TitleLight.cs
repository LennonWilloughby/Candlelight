using UnityEngine;
using System.Collections;

public class TitleLight : MonoBehaviour {

	// Public
	public float lightLow = 6.0f;
	public float lightHigh = 3.0f;
	public float lightSmall = 2.0f;
	public float lightLarge = 100.0f;
	public float changeSpeed = 0.75f;
	public bool hover = false;

	// Private
	private float lightValue = 0.0f; // the amount of light entering the sensor

	
	// Use this for initialization
	void Start () {

# if UNITY_ANDROID
		// Activate the light sensor
		Sensor.Activate (Sensor.Type.Light);
#endif
		// initialises light intensity
		light.intensity = lightLow;
	
	}
	
	// Update is called once per frame
	void Update () {

# if UNITY_ANDROID
		// update light value
		lightValue  = Sensor.light;
		SensorLight (); //Use a light via the android light sensor
#endif

		HoverLight (); //Use a light via mouse position
	}

	void OnMouseEnter() {
		hover = true;
	}

	void OnMouseExit() {
		hover = false;
	}


	void HoverLight () {

		// if mouse is hovering on collider increase light intensity
		if (hover) {
			light.range = Mathf.Lerp(light.range, lightLarge, changeSpeed * Time.deltaTime);
			light.intensity = Mathf.Lerp(light.intensity, lightHigh, changeSpeed * Time.deltaTime);
		}
		else {
			light.range = Mathf.Lerp(light.range, lightSmall, changeSpeed * Time.deltaTime);
			light.intensity = Mathf.Lerp (light.intensity, lightLow, changeSpeed * Time.deltaTime);
		}
	}

	void SensorLight () {

		if (lightValue > 5) {
			lightValue = 5;
		}

		light.intensity = Mathf.Lerp(light.intensity, lightValue, changeSpeed * Time.deltaTime);
		light.range = Mathf.Lerp(light.range, lightValue * 20, changeSpeed * Time.deltaTime);
	}

}
