using UnityEngine;
using System.Collections;

public class SceneBehaviour : MonoBehaviour {
	private GameObject selectedObj;
	//Camera camera;

	// Use this for initialization
	void Start () {
		//selectedObj = ;
		//camera = 
	}
	
	// Update is called once per frame
	void Update () {
		float turnSpeed = 45.0f;
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Camera camera = GameObject.Find ("Camera").GetComponent<Camera>();
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform != null) {
					Debug.Log ("Hit " + hit.transform.gameObject.name);
					//hit.transform.gameObject.transform.Rotate (Vector3.up * turnSpeed);
					SelectObject (hit.transform.gameObject);
				}
			} else {
				ClearSelection ();
			}
		}
	}

	public void CheckDisappearingObject(GameObject obj) {
		if (obj == selectedObj)
			ClearSelection ();
	}

	public void SelectObject(GameObject obj) {
		print ("Select object " + obj.name);
		selectedObj = obj;
	}

	public void ClearSelection() {
		print ("Clear Selection");
		selectedObj = null;
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

		print ("Change color: " + selectedObj);
		print (selectedObj);
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
