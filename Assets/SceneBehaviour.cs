using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneBehaviour : MonoBehaviour {
	public float minSwipeDistY;
	public float minSwipeDistX;
	private Vector2 startPos;
	private GameObject manipulatedObj;

	private List<ARMarker> visibleMarkers = new List<ARMarker> (); 

	int SWIPE_THRESHOLD = 50;
	int PALETTE_THRESHOLD = 160;
	float DIST_THRESHOLD = 0.4F;

	// Use this for initialization
	void Start () {
	}

	private GameObject DetectTarget() {
		GameObject target = null;

		RaycastHit hit;
		Camera camera = GameObject.Find ("Camera").GetComponent<Camera>();
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			Debug.Log ("Hit " + hit.transform.gameObject.name);
			target = hit.transform.gameObject;
		}

		return target;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			switch (touch.phase) {

			case TouchPhase.Began:
				manipulatedObj = DetectTarget ();
				startPos = touch.position;

				break;
			case TouchPhase.Ended:
				float swipeValue;
				float swipeDistVertical = (new Vector3 (0, touch.position.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;
				if (swipeDistVertical > minSwipeDistY) {
					swipeValue = Mathf.Sign (touch.position.y - startPos.y);

					if (swipeValue > 0) {
					} // up swipe
					else if (swipeValue < 0) {
					} //down swipe
				}

				float swipeDistHorizontal = (new Vector3 (touch.position.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;

				swipeValue = (touch.position.x - startPos.x);

				if (manipulatedObj) {
					if (swipeValue > SWIPE_THRESHOLD) { //right swipe
						manipulatedObj.transform.Rotate (new Vector3 (0, 270, 0));
					} else if (swipeValue < -SWIPE_THRESHOLD) { //left swipe
						manipulatedObj.transform.Rotate (new Vector3 (0, 90, 0));
					} else {
						ObjectTap (manipulatedObj);
					}
				}
				else
					if (touch.position.y < Screen.height - PALETTE_THRESHOLD) {
						TapOutside ();
					}

				break;
			}
		}
		else if (Input.GetMouseButtonDown(0)) {
			GameObject obj = DetectTarget();
			if (obj)
				ObjectTap (obj);
			else if (Input.mousePosition.y < Screen.height - PALETTE_THRESHOLD) {
				TapOutside ();
			}
		}

		DetectCloseObject ();
	}

	private void DetectCloseObject() {
		float minDist = 1000;
		GameObject closestObj = null;

		Camera camera = GameObject.Find ("Camera").GetComponent<Camera>();
		var cameraPosition = camera.transform.position;

		foreach (var obj in GameObject.FindGameObjectsWithTag("AllMarkerTag")) {
			if (visibleMarkers.Contains (obj.GetComponent<ARTrackedObject>().GetMarker ())) {

				var marker = obj.GetComponent<ARTrackedObject> ();
				var position = marker.transform.position;
				float dist = Vector3.Distance (cameraPosition, position);
				if (dist < minDist) {
					minDist = dist;
					closestObj = obj;
				}
			}
		}

		if (closestObj && minDist < DIST_THRESHOLD) {
			var furniture = closestObj.transform.Find ("Container").transform.Find ("Furniture");
			Sprite objName = furniture.GetComponent<FurnitureBehaviour> ().Name;
			Sprite objPrice = furniture.GetComponent<FurnitureBehaviour> ().Price;
			GameObject.Find ("NameText").GetComponent<Image> ().sprite = objName;
			GameObject.Find ("PriceText").GetComponent<Image> ().sprite = objPrice;
		} else {
			//GameObject.Find ("NameText").GetComponent<Image> ().text = "1";
			//GameObject.Find ("PriceText").GetComponent<Image> ().text = "2";
		}
	}

	private void ObjectTap(GameObject obj) {
		if (!IsSelected (obj))
			SelectObject (obj);
	}

	private void TapOutside() {
		var prevSelectedObj = GetSelection ();
		if (prevSelectedObj)
			ClearSelection (prevSelectedObj);
	}

	private void SelectObject(GameObject obj) {
		obj.GetComponent<FurnitureBehaviour> ().Select ();

		GameObject.Find ("ColorPalette").GetComponent<PaletteBehaviour> ().Show ();
	}

	private void ClearSelection(GameObject obj) {
		print ("Clear Selection");
		obj.GetComponent<FurnitureBehaviour> ().Deselect ();

		GameObject.Find ("ColorPalette").GetComponent<PaletteBehaviour> ().Hide ();
		//var objects = GameObject.FindGameObjectsWithTag ("SelectedFurniture");
		//foreach (var obj in objects)
		//	obj.tag = "Untagged";
	}

	private bool IsSelected(GameObject obj) {
		return obj.GetComponent<FurnitureBehaviour> ().IsSelected ();
	}

	private GameObject GetSelection() {
		var objects = GameObject.FindGameObjectsWithTag ("FurnitureTag");
		foreach (var obj in objects) {
			if (IsSelected (obj))
				return obj;
		}
		return null;
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
		visibleMarkers.Remove (marker);
		//GameObject obj = GameObject.Find (marker.name + "/Container/Furniture");
		//CheckDisappearingObject(obj);
	}

	public void OnMarkerFound(ARMarker marker) {
		visibleMarkers.Add (marker);
	}
}
