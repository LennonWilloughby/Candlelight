using UnityEngine;
using System.Collections;

public class LightSource : MonoBehaviour {

	// Public
	public float lightLow = 0.0f; // lowest light intensity. off
	public float lightHigh = 10.0f; // highest light intesity. on
	public float fadeSpeed = 4.0f; // how long it takes to fade between lowest and highest light intensities
	public float lightThreshold = 10.0f; // threshold for if light entering sensor is enough to change the light intensity
	public static bool lightState = false; // whether the light is on or off
	public static float lux = 0; // a measure of illuminance

	// Private
	private float lightValue = 0.0f; // the amount of light entering the sensor
	

	// Use this for initialization
	void Start () {
		// Activate the light sensor
		Sensor.Activate (Sensor.Type.Light);
	}
	
	// Update is called once per frame
	void Update () {

		// update light value and lux
		lightValue  = Sensor.light;
		lux = lightValue;

# if UNITY_STANDALONE
		FadeLight (); // Use a fading light via keyboard
#endif
		//InstantLight (); // Use an instant light via keyboard

# if UNITY_ANDROID
		SensorLight (); // Use a fading light via the android light sensor
#endif

	}

	// Instant light on and off
	void InstantLight() {

		// If spacebar is pressed light is on
		if (Input.GetKey("space"))
		{
			lightState = true;
			light.intensity = lightHigh;
		}

		// If spacebar is not pressed light is off
		if (!Input.GetKey("space"))
		{
			lightState = false;
			light.intensity = lightLow;
		}
	}

	// Fading effect between on and off light
	void FadeLight() {

		// If spacebar is pressed light fades on
		if (Input.GetKey("space"))
		{
			lightState = true;
			light.intensity = Mathf.Lerp(light.intensity, lightHigh, fadeSpeed * Time.deltaTime);
		}

		// If spacebar is not pressed light fades off
		if (!Input.GetKey("space"))
		{
			lightState = false;
			light.intensity = Mathf.Lerp(light.intensity, lightLow, fadeSpeed * Time.deltaTime);
		}

	}

	// Android light sensor determines if light is on or off
	void SensorLight() { 

		// If lightvalue is greater than the set threshold light fades on
		if (lightValue >= lightThreshold)
		{
			lightState = true;
			light.intensity = Mathf.Lerp(light.intensity, lightHigh, fadeSpeed * Time.deltaTime);
		}

		// If lightvalue is less than the set threshold light fades off
		if (lightValue < lightThreshold)
		{
			lightState = false;
			light.intensity = Mathf.Lerp(light.intensity, lightLow, fadeSpeed * Time.deltaTime);
		}

		//
		//
		// Check if this works
		// Changing light in game based on light recieved by sensor rather than preset values
		//
		//light.intensity = Mathf.Lerp(light.intensity, lightValue, fadeSpeed * Time.deltaTime);
		
	}

}
