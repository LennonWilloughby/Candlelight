using UnityEngine;
using System.Collections;

public class HowToNoise : MonoBehaviour {
	
	public Texture howToTexture;
	public Texture howToTexturePC;
	public Texture howToTextureAndroid;
	
	private Color fadeColor;
	private bool fadeIn = true;
	private bool fadeOut = false;
	private float fadeTime = 0;
	
	// Use this for initialization
	void Start () {

# if UNITY_STANDALONE
		howToTexture = howToTexturePC;
#endif
# if UNITY_ANDROID
		howToTexture = howToTextureAndroid;
#endif
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (fadeIn){
			fadeTime += Time.deltaTime/2;
			fadeColor = Color.Lerp (new Color (1, 1, 1, 0), new Color (1, 1, 1, 1), fadeTime);
			
			if (Input.GetMouseButtonDown(1)){
				fadeIn = false;
				fadeOut = true;
				fadeTime = 0;
			}
		}
		else if (fadeOut){
			fadeTime += Time.deltaTime/2;
			fadeColor = Color.Lerp (new Color (1, 1, 1, 1), new Color (1, 1, 1, 0), fadeTime);
		}
		
	}
	
	void OnGUI() {
		
		GUI.color = fadeColor;
		GUI.DrawTexture(new Rect(Screen.width/8, Screen.height/8, Screen.width - Screen.width/4, Screen.height - Screen.height/4), howToTexture, ScaleMode.StretchToFill, true, 10.0F);
	}
}