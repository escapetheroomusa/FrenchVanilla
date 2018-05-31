using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterRotationScript : MonoBehaviour {
	public static float redRotation = 0.0f;
	public static float blueRotation = 0.0f;
	public static float greenRotation = 0.0f;
	public Slider redSlider;
	public Slider blueSlider;
	public Slider greenSlider;
	public GameObject objectPrefab;
	public GameObject gridAnchor;
	public Canvas baseCanvas;
	public Text solvedText;
	// Use this for initialization
	void Start () {
		Vector3 startPos = gridAnchor.transform.localPosition;
		float xOffset = 150;
		float yOffset = 150;
		for (int i = 0; i < 2; i++) {
			for (int j = 0; j < 7; j++) {
				Vector3 objPos = new Vector3 (startPos.x + j * xOffset, startPos.y - i * yOffset);
				int index = 7 * i + j;
				initRotationObject(RotationObjectScript.GameColor.RED, objPos, index);
				initRotationObject(RotationObjectScript.GameColor.BLUE, objPos, index);
				initRotationObject(RotationObjectScript.GameColor.GREEN, objPos, index);
			}
		}
		redSlider.value = Random.Range (0.0f, 1.0f);
		blueSlider.value = Random.Range (0.0f, 1.0f);
		greenSlider.value = Random.Range (0.0f, 1.0f);
	}

	private void initRotationObject(RotationObjectScript.GameColor color, Vector3 pos, int index){
		GameObject blueObject = (GameObject)Instantiate (objectPrefab);
		blueObject.transform.SetParent (baseCanvas.transform);
		blueObject.transform.localPosition = pos;
		blueObject.GetComponent<RotationObjectScript> ().initObject (color, index);
	}
	float solvedOffset = 20.0f;
	// Update is called once per frame
	void Update () {
		redRotation = 360.0f * redSlider.value;
		blueRotation = 30.0f + 360.0f * blueSlider.value;
		greenRotation = 90.0f + 360.0f * greenSlider.value;
		if ((redRotation % 360.0f  < solvedOffset)
			&& (blueRotation % 360.0f < solvedOffset)
			&& (greenRotation % 360.0f < solvedOffset)) {
			solvedText.gameObject.SetActive (true);
		} else {
			solvedText.gameObject.SetActive (false);
		}
	}
}
