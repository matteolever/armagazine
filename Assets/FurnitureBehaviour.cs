using UnityEngine;
using System.Collections;

public class FurnitureBehaviour : MonoBehaviour {
	private bool selected = false;

	public string Name { get; set; }
	public string Price { get; set; }

	Color vis = new Color (255, 255, 255, 255);
	Color transp = new Color (255, 255, 255, 0);

	void Start () {
		transform.Find ("Selection").GetComponent<Renderer> ().material.color = transp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Select() {
		if (!selected) {
			selected = true;
			transform.Find ("Selection").GetComponent<Renderer> ().material.color = vis;
		}
	}

	public void Deselect() {
		if (selected) {
			selected = false;
			GameObject.Find ("Selection").GetComponent<Renderer> ().material.color = transp;
		}
	}

	public bool IsSelected() {
		return selected;
	}
}
