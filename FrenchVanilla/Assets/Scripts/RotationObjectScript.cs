using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObjectScript : MonoBehaviour {
	public enum GameColor
	{
		RED =0,
		BLUE,
		GREEN
	};
	public GameColor gColor;
	// Use this for initialization
	void Start () {
		
	}

	public void initObject(GameColor color, int num){
		gColor = color;
		string redPrefix = "01_red_segments";
		string bluePrefix = "02_blue_segments";
		string greenPrefix = "03_green_segments";
		string spriteName = "";
		switch (color) {
		case GameColor.RED:
			spriteName = redPrefix;
			break;
		case GameColor.GREEN:
			spriteName = greenPrefix;
			break;
		case GameColor.BLUE:
			spriteName = bluePrefix;
			break;
		}
		//spriteName += num.ToString ();
		Debug.Log (spriteName);
		Sprite[] sprites = Resources.LoadAll<Sprite>(spriteName);
		this.GetComponent<SpriteRenderer> ().sprite = sprites [num];
	}

	// Update is called once per frame
	void Update () {
		float rotValue = 0.0f;
		switch (gColor) {
		case GameColor.GREEN:
			rotValue = MasterRotationScript.greenRotation;
			break;
		case GameColor.BLUE:
			rotValue = MasterRotationScript.blueRotation;
			break;
		case GameColor.RED:
			rotValue = MasterRotationScript.redRotation;
			break;
		}
		transform.localRotation = Quaternion.Euler (0, 0, rotValue);
	}
}
