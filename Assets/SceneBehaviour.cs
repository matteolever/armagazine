using UnityEngine;
using System.Collections;

public class SceneBehaviour : MonoBehaviour {
	private static GameObject selectedObj;

	// Use this for initialization
	void Start () {
		//selectedObj = ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CheckDisappearingObject(GameObject obj) {
		if (obj == selectedObj)
			DeselectCurrentObject ();
	}

	public void DeselectCurrentObject() {
		if (selectedObj) {
			selectedObj = null;
		}
	}

	public void SelectObject(GameObject obj) {
		print ("SelectObject!!!!!!!!!!!");
		//DeselectCurrentObject ();
		selectedObj = obj;
		print (selectedObj);
	}

	public void ChangeColor (string color) {
		Color c = Color.gray;
		switch (color) {
		case "white":
			c = Color.white;
			break;
		case "black":
			c = Color.black;
			break;
		case "red":
			c = Color.red;
			break;
		case "yellow":
			c = Color.yellow;
			break;
		case "blue":
			c = Color.blue;
			break;
		}

		selectedObj = GameObject.Find ("ArmchairMarker/Container/Furniture");
		if (selectedObj != null)
			selectedObj.GetComponent<Renderer>().material.color = c;
	}

	public void OnMarkerLost(ARMarker marker) {
		//GameObject obj = GameObject.Find (marker.name + "/Container/Furniture");
		//CheckDisappearingObject(obj);
	}

	public void OnMarkerFound(ARMarker marker) {
	}
}
