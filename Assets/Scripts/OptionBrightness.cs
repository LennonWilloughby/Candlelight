using UnityEngine;
using System.Collections;

public class OptionBrightness : MonoBehaviour {

	private Color brightnessDarkest = Color.black;
	private Color brightnessLightest = Color.gray;
	private float brightnessValue = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GameManager.brightness = Color.Lerp(brightnessDarkest, brightnessLightest, brightnessValue);
	
	}


	void OnGUI() {

		brightnessValue = GUI.HorizontalSlider(new Rect(590, 210, 210, 10), brightnessValue, 0.0f, 1.0f);

	}
}
