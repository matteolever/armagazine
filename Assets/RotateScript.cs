using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {
	public float minSwipeDistY;
	public float minSwipeDistX;
	private Vector2 startPos;


	// Use this for initialization
	void Start () {
		//selectedObj = ;
	}

	// Update is called once per frame
	void Update ()
	{

		if (Input.touchCount > 0) {
			GameObject obj = GameObject.Find ("Armchair");
			Touch touch = Input.touches [0];
			switch (touch.phase) {

			case TouchPhase.Began:
				startPos = touch.position;
				break;
			case TouchPhase.Ended:
				float swipeDistVertical = (new Vector3 (0, touch.position.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;
				if (swipeDistVertical > minSwipeDistY) {
					float swipeValue = Mathf.Sign (touch.position.y - startPos.y);

					if (swipeValue > 0) { //up swipe
						//Jump ();
					} else if (swipeValue < 0) {//down swipe
						//Shrink ();
					}

				}

				float swipeDistHorizontal = (new Vector3 (touch.position.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;

				if (swipeDistHorizontal > minSwipeDistX) {

					float swipeValue = Mathf.Sign (touch.position.x - startPos.x);

					if (swipeValue > 0) {//right swipe
						//MoveRight ();
						obj.transform.Rotate (new Vector3 (0, 270, 0));
					} else if (swipeValue < 0) { //left swipe

						//MoveLeft ();
						obj.transform.Rotate (new Vector3 (0, 90, 0));
					}

				}

				break;
			}
		}
	}
}