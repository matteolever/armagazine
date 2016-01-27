using UnityEngine;
using System.Collections;

public class DescriptionBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.Translate (new Vector2 (0, -Screen.height / 2 + 20));
		//transform.Find("NameText").Translate (new Vector2 (-Screen.width / 2 + 200, 0));
		//transform.Find("PriceText").Translate (new Vector2 (Screen.width / 2 - 200, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
