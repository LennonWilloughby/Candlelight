﻿using UnityEngine;
using System.Collections;

public class Brightness : MonoBehaviour {

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		RenderSettings.ambientLight = GameManager.brightness;
	
	}
}
