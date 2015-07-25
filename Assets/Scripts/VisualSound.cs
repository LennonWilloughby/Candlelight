using UnityEngine;
using System.Collections;

public class VisualSound : MonoBehaviour {

	public float tooSoft = 1.0f; //check if sound is too soft to hear
	public float tooLoud = 20.0f; //check if sound is too loud to hear
	public GameObject sound;

	private MicControlC mic; // holds instance of MicControlC script
	private float loudness; // holds loudness value from mic input

	// Use this for initialization
	void Start () {

		// Gets an instance of the MicControlC script from the target variable
		mic = GetComponent<MicControlC> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		loudness = mic.loudness;// Update loudness
		if (loudness > tooLoud){
			loudness = tooLoud;
		}
		if (loudness > tooSoft){
			GameObject instance = (GameObject)Instantiate(sound, transform.position, transform.rotation);
			instance.transform.localScale += new Vector3 (loudness,0,loudness);
		}
	
	}
}
