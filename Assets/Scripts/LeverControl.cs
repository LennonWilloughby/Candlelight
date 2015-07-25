using UnityEngine;
using System.Collections;

public class LeverControl : MonoBehaviour {

	public float leverDistance = 4.0f;
	public AudioClip leverSound;

	private bool lever1 = false;
	private bool lever2 = false;

	private GameObject player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

		UnlockGate ();
	
	}

	void UnlockGate() {

		foreach (Transform child in transform)
		{
			if(child.name == "Lever1")
			{
				if(Vector3.Distance(child.transform.position, player.transform.position) < leverDistance && lever1 == false)
				{
					AudioSource.PlayClipAtPoint (leverSound, child.transform.position, 1.0f);
					lever1 = true;

				}
			}
			if(child.name == "Lever2")
			{
				if(Vector3.Distance(child.transform.position, player.transform.position) < leverDistance && lever2 == false)
				{
					AudioSource.PlayClipAtPoint (leverSound, child.transform.position, 1.0f);
					lever2 = true;
				}
			}
			if(child.name == "HorizontalBars" && lever1 == true)
			{
				Destroy(child.gameObject);
			}
			if(child.name == "VerticalBars" && lever2 == true)
			{
				Destroy(child.gameObject);
			}
		}
	}
}
