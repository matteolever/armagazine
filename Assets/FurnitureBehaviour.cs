using UnityEngine;
using System.Collections;

public class FurnitureBehaviour : MonoBehaviour {
	private bool selected = false;
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Select() {
		if (!selected) {
			selected = true;
		}
	}

	public void Deselect() {
		if (selected) {
			selected = false;
		}
	}

	public bool IsSelected() {
		return selected;
	}
}
