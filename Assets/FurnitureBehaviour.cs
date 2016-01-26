using UnityEngine;
using System.Collections;

public class FurnitureBehaviour : MonoBehaviour {
	private bool selected = false;
	// Use this for initialization

	Color vis = new Color (255, 255, 0);
	Color transp = new Color (0, 255, 255);

	void Start () {
		GameObject.Find ("Cube").GetComponent<Renderer> ().material.color = transp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Select() {
		if (!selected) {
			selected = true;
			GameObject.Find ("Cube").GetComponent<Renderer> ().material.color = vis;
		}
	}

	public void Deselect() {
		if (selected) {
			selected = false;
			GameObject.Find ("Cube").GetComponent<Renderer> ().material.color = transp;
		}
	}

	public bool IsSelected() {
		return selected;
	}
}
