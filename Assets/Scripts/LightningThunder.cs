using UnityEngine;
using System.Collections;

public class LightningThunder : MonoBehaviour {

	public float minTime = 0.4f;
	public float threshold = 0.85f;

	private float lastTime = 0;
	private float thunderType = 0;

	public AudioSource[] sounds;
	public AudioSource thunder0;
	public AudioSource thunder1;
	public AudioSource thunder2;
	public AudioSource thunder3;
	public AudioSource thunder4;

	// Use this for initialization
	void Start () {

		sounds = GetComponents<AudioSource> ();
		thunder0 = sounds [0];
		thunder1 = sounds [1];
		thunder2 = sounds [2];
		thunder3 = sounds [3];
		thunder4 = sounds [4];
	
	}
	
	// Update is called once per frame
	void Update () {

		if ((Time.time - lastTime) > minTime) {
			LightningFlash();
		}
	
	}

	void LightningFlash() {

		if (Random.value > threshold) {
			light.enabled = true;
			StartCoroutine(ThunderCrash());
		}
		else {
			light.enabled = false;
		}
		lastTime = Time.time;
	}

	IEnumerator ThunderCrash() {

		thunderType = Random.value;
		yield return new WaitForSeconds(1 + thunderType);
		if (thunderType <= 0.2)
			if (!thunder0.isPlaying)
				thunder0.Play();
		if (thunderType > 0.2 && thunderType <= 0.4)
			if (!thunder1.isPlaying)
				thunder1.Play();
		if (thunderType > 0.4 && thunderType <= 0.6)
			if (!thunder2.isPlaying)
				thunder2.Play();
		if (thunderType > 0.6 && thunderType <= 0.8)
			if (!thunder3.isPlaying)
				thunder3.Play();
		if (thunderType > 0.8)
			if (!thunder4.isPlaying)
				thunder4.Play();
	}
}
