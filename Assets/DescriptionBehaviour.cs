using UnityEngine;
using System.Collections;

public class DescriptionBehaviour : MonoBehaviour {
	bool hidden = true;

	// Use this for initialization
	void Start () {
		transform.Translate (new Vector2 (0, -Screen.height / 2 - 120));
		transform.Find("NameImage").Translate (new Vector2 (-Screen.width / 2 + 500, 0));
		transform.Find("PriceImage").Translate (new Vector2 (Screen.width / 2 - 500, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Show() {
		if (hidden) {
			transform.Translate (new Vector2 (0, 240));
			hidden = false;
		}
	}

	public void Hide() {
		if (!hidden) {
			transform.Translate (new Vector2 (0, - 240));
			hidden = true;
		}
	}
}
