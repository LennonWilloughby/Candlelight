using UnityEngine;
using System.Collections;

public class ReturnToFoyer : MonoBehaviour {

	private float distance = 5.0f;
	private GameObject player; // game object for holding instance of player object
	
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.FindWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Vector3.Distance(transform.position, player.transform.position) < distance){

			if(Application.loadedLevelName == "LevelDungeonAlt"){
				PlayerPrefs.SetInt("dungeonComplete", 1);
				if (GameManager.dungeonTimer < PlayerPrefs.GetFloat("dungeonTime") || PlayerPrefs.GetFloat("dungeonTime") == 0)
					PlayerPrefs.SetFloat("dungeonTime", GameManager.dungeonTimer);
			}
			if(Application.loadedLevelName == "LevelLibraryAlt"){
				PlayerPrefs.SetInt("libraryComplete", 1);
				if (GameManager.libraryTimer < PlayerPrefs.GetFloat("libraryTime") || PlayerPrefs.GetFloat("libraryTime") == 0)
					PlayerPrefs.SetFloat("libraryTime", GameManager.libraryTimer);
			}
			if(Application.loadedLevelName == "LevelDiningHallAlt"){
				PlayerPrefs.SetInt("diningHallComplete", 1);
				if (GameManager.diningHallTimer < PlayerPrefs.GetFloat("diningHallTime") || PlayerPrefs.GetFloat("diningHallTime") == 0)
					PlayerPrefs.SetFloat("diningHallTime", GameManager.diningHallTimer);
			}
			if(Application.loadedLevelName == "LevelLaboratoryAlt"){
				PlayerPrefs.SetInt("laboratoryComplete", 1);
				if (GameManager.laboratoryTimer < PlayerPrefs.GetFloat("laboratoryTime") || PlayerPrefs.GetFloat("laboratoryTime") == 0)
					PlayerPrefs.SetFloat("laboratoryTime", GameManager.laboratoryTimer);
			}
			if(Application.loadedLevelName == "LevelThroneRoomAlt"){
				PlayerPrefs.SetInt("throneRoomComplete", 1);
				if (GameManager.throneRoomTimer < PlayerPrefs.GetFloat("throneRoomTime") || PlayerPrefs.GetFloat("throneRoomTime") == 0)
					PlayerPrefs.SetFloat("throneRoomTime", GameManager.throneRoomTimer);
			}
			PlayerPrefs.Save();


			AutoFade.LoadLevel("LevelFoyerAlt", 1, 1, Color.black);
			//Application.LoadLevel(level);

		}
	}
}