using UnityEngine;
using System.Collections;

public class SceneBehaviour : MonoBehaviour {
	public float minSwipeDistY;
	public float minSwipeDistX;
	private Vector2 startPos;
	private GameObject manipulatedObj;

	int SWIPE_THRESHOLD = 50;

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
				manipulatedObj = DetectTarget();
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

				break;
			}
		}
		else if (Input.GetMouseButtonDown(0)) {
			GameObject obj = DetectTarget();
			if (obj)
				ObjectTap (obj);
		}
	}

	private void ObjectTap(GameObject obj) {
		if (IsSelected (obj))
			ClearSelection (obj);
		else
			SelectObject (obj);
	}

	private void SelectObject(GameObject obj) {
		obj.tag = "SelectedFurniture";

		GameObject.Find ("ColorPalette").GetComponent<PaletteBehaviour> ().Show ();
	}

	private void ClearSelection(GameObject obj) {
		obj.tag = "Untagged";
		print ("Clear Selection");

		GameObject.Find ("ColorPalette").GetComponent<PaletteBehaviour> ().Hide ();
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
