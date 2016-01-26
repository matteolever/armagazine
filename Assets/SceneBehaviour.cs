using UnityEngine;
using System.Collections;

public class SceneBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Camera camera = GameObject.Find ("Camera").GetComponent<Camera>();
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform != null) {
					Debug.Log ("Hit " + hit.transform.gameObject.name);
					if (IsSelected (hit.transform.gameObject))
						ClearSelection (hit.transform.gameObject);
					else
						SelectObject (hit.transform.gameObject);
				}
			}
		}
	}

	private void SelectObject(GameObject obj) {
		obj.tag = "SelectedFurniture";
	}

	private void ClearSelection(GameObject obj) {
		obj.tag = "Untagged";
		print ("Clear Selection");
		//var objects = GameObject.FindGameObjectsWithTag ("SelectedFurniture");
		//foreach (var obj in objects)
		//	obj.tag = "Untagged";
	}

	private bool IsSelected(GameObject obj) {
		return obj.tag == "SelectedFurniture";
	}

	private GameObject GetSelection() {
		return GameObject.FindGameObjectWithTag ("SelectedFurniture");
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

		GameObject selectedObj = GetSelection();
		if (selectedObj != null) {
			print ("Change color");
			selectedObj.GetComponent<Renderer> ().material.color = c;
		}
	}

	public void OnMarkerLost(ARMarker marker) {
		//GameObject obj = GameObject.Find (marker.name + "/Container/Furniture");
		//CheckDisappearingObject(obj);
	}

	public void OnMarkerFound(ARMarker marker) {
	}
}
