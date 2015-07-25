using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	public float lifetime = 0.2f;

	// Use this for initialization
	void Start () {
	
		ChangeAlpha(gameObject.renderer.material, 0.1f);
		Destroy(gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void ChangeAlpha(this Material mat, float alpha)
	{
		Color oldColor = mat.color;
		Color newColor = new Color(oldColor.r, oldColor.b, oldColor.g, alpha);          
		mat.SetColor("_Color", newColor);               
	}
}
