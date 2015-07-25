using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {


	public AudioClip menuTheme;
	public AudioClip ambienceLight;
	public AudioClip ambienceSuspenseful;
	public AudioClip ambienceIntense;
	public AudioClip bossTheme;


	private static bool created = false;
	private string level;
	private GameObject player = null; // game object for holding instance of player position
	

	// Use this for initialization
	void Start () {

		audio.clip = menuTheme;
		audio.Play ();

		if (!created){
			DontDestroyOnLoad (transform.gameObject);
			created = true;
		}
		else{
			Destroy(transform.gameObject);
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if (player != null){
			transform.position = player.transform.position;

		}
	
	}


	void OnLevelWasLoaded (){

		if (GameObject.FindWithTag("Player") != null)
			player = GameObject.FindWithTag("Player");
		else{
			player = null;
		}

		if(player == null){
			transform.position = GameObject.FindWithTag("MainCamera").transform.position;

		}

		level = Application.loadedLevelName;

		if (level == "MenuMain" || level == "MenuLevel" || level == "MenuOptions" || level == "MenuLevelTimes" || level == "LevelDiningHall"){
			if (audio.clip != menuTheme){
				audio.Stop();
				audio.clip = menuTheme;
				audio.Play ();
			}
			if (!audio.isPlaying){
				audio.clip = menuTheme;
				audio.Play();
			}
		}
		if (level == "LevelOutside" || level == "LevelFoyer" || level == "LevelFoyerAlt"){
			audio.Stop();

		}
		if (level == "LevelDungeon" || level == "LevelLibrary" || level == "LevelLaboratoryAlt"){
			audio.Stop();
			audio.clip = ambienceLight;
			audio.Play();

		}
		if (level == "LevelDungeonAlt" || level == "LevelLaboratory"){
			audio.Stop();
			audio.clip = ambienceSuspenseful;
			audio.Play();
			
		}
		if (level == "LevelLibraryAlt" || level == "LevelDiningHallAlt"){
			audio.Stop();
			audio.clip = ambienceIntense;
			audio.Play();
			
		}
		if (level == "LevelThroneRoom" || level == "LevelThroneRoomAlt"){
			if (audio.clip != bossTheme){
				audio.Stop();
				audio.clip = bossTheme;
				audio.Play();
			}
			
		}
	}

}
	

