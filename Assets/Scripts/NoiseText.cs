﻿using UnityEngine;
using System.Collections;

public class NoiseText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		gameObject.guiText.text = "Noise: " + MicControlC.noise.ToString();
	}
}
