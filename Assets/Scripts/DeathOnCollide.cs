using UnityEngine;
using System.Collections;

public class DeathOnCollide : MonoBehaviour {

	public AudioClip blow;
	public bool deathByGhost = false;

	private int currentLevel;
	private bool killable = true;
	private bool dead = false;

	// Use this for initialization
	void Start () {

		currentLevel = Application.loadedLevel;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (deathByGhost && killable) {
			dead = true;
			killable = false;
			AudioSource.PlayClipAtPoint (blow, transform.position, 0.5f);

		}

		if (dead){
			AutoFade.LoadLevel (currentLevel, 0.5f, 2, Color.black);
			//Application.LoadLevel (currentLevel);

		}
	
	}


	void OnCollisionEnter(){

		dead = true;

	}

}
