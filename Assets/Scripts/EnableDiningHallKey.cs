﻿using UnityEngine;
using System.Collections;

public class EnableDiningHallKey : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
		if (PlayerPrefs.GetInt("diningHallComplete") == 1) {
			foreach (Transform child in transform){
				if (child.gameObject.renderer)
					child.gameObject.renderer.enabled = true;
				if (child.gameObject.light)
					child.gameObject.light.enabled = true;
			}
		}
		else{
			foreach (Transform child in transform){
				if (child.gameObject.renderer)
					child.gameObject.renderer.enabled = false;
				if (child.gameObject.light)
					child.gameObject.light.enabled = false;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
