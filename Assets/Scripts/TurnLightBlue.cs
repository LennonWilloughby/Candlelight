using UnityEngine;
using System.Collections;

public class TurnLightBlue : MonoBehaviour {
	
	private Color bluish = new Color(0.58f, 0.78f, 1, 1);
	
	// Use this for initialization
	void Start () {
		
		if (PlayerPrefs.GetInt("throneRoomComplete") == 1){
			
			transform.gameObject.light.color = bluish;
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
