using UnityEngine;
using System.Collections;

public class SceneBehaviour : MonoBehaviour {
	private GameObject selectedObj = null;

	// Use this for initialization
	void Start () {
		selectedObj = GameObject.Find ("Armchair");
	}
	
	// Update is called once per frame
	void Update () {
	
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

		if (selectedObj != null)
			selectedObj.GetComponent<Renderer>().material.color = c;
	}
}
