using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//switch for microphone
	public static bool micOn = false;

	//level timers
	public static float dungeonTimer = 0;
	public static float libraryTimer = 0;
	public static float diningHallTimer = 0;
	public static float laboratoryTimer = 0;
	public static float throneRoomTimer = 0;
	
	private static bool created = false;

	//brightness option value
	public static Color brightness;

	//volume option value
	public static float volume;


	// Use this for initialization
	void Start () {

		if (!created){
			DontDestroyOnLoad (transform.gameObject);
			created = true;
		}
		else{
			Destroy(transform.gameObject);
		}


		if (PlayerPrefs.HasKey("dungeonComplete") == false){
			PlayerPrefs.SetInt ("dungeonComplete", 0);
		}
		if (PlayerPrefs.HasKey("libraryComplete") == false){
			PlayerPrefs.SetInt ("libraryComplete", 0);
		}
		if (PlayerPrefs.HasKey("diningHallComplete") == false){
			PlayerPrefs.SetInt ("diningHallComplete", 0);
		}
		if (PlayerPrefs.HasKey("laboratoryComplete") == false){
			PlayerPrefs.SetInt ("laboratoryComplete", 0);
		}
		if (PlayerPrefs.HasKey("throneRoomComplete") == false){
			PlayerPrefs.SetInt ("throneRoomComplete", 0);
		}

		if (PlayerPrefs.HasKey("dungeonTime") == false){
			PlayerPrefs.SetInt ("dungeonTime", 0);
		}
		if (PlayerPrefs.HasKey("libraryTime") == false){
			PlayerPrefs.SetInt ("libraryTime", 0);
		}
		if (PlayerPrefs.HasKey("diningHallTime") == false){
			PlayerPrefs.SetInt ("diningHallTime", 0);
		}
		if (PlayerPrefs.HasKey("laboratoryTime") == false){
			PlayerPrefs.SetInt ("laboratoryTime", 0);
		}
		if (PlayerPrefs.HasKey("throneRoomTime") == false){
			PlayerPrefs.SetInt ("throneRoomTime", 0);
		}

		//PlayerPrefs.DeleteAll();		//Uncomment to clear player prefs

		PlayerPrefs.Save ();
	}
	
	// Update is called once per frame
	void Update () {

		//Increment level timer while player is in the level
		if(Application.loadedLevelName == "LevelDungeon" || Application.loadedLevelName == "LevelDungeonAlt"){
			dungeonTimer += Time.deltaTime;
		}
		if(Application.loadedLevelName == "LevelLibrary" || Application.loadedLevelName == "LevelLibraryAlt"){
			libraryTimer += Time.deltaTime;
		}
		if(Application.loadedLevelName == "LevelDiningHall" || Application.loadedLevelName == "LevelDiningHallAlt"){
			diningHallTimer += Time.deltaTime;
		}
		if(Application.loadedLevelName == "LevelLaboratory" || Application.loadedLevelName == "LevelLaboratoryAlt"){
			laboratoryTimer += Time.deltaTime;
		}
		if(Application.loadedLevelName == "LevelThroneRoom" || Application.loadedLevelName == "LevelThroneRoomAlt"){
			throneRoomTimer += Time.deltaTime;
		}
	}
}
