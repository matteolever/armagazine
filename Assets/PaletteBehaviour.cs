﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PaletteBehaviour : MonoBehaviour {
	private Color[] colors = {Color.black, Color.white, Color.gray, Color.yellow, Color.red, Color.blue};
	//private List<Button> colorButtons = new List<Button>();



	void OnGUI() {
		/*
		int i = 0;
		int width = 100;
		int widthMargin = 120;
		foreach (Color color in colors) {
			GUI.color = color;
			GUI.Button (new Rect(Screen.width / 2 + widthMargin * i - widthMargin * colors.Length / 2, 10, width, width),
				"Red");
			Button b = GetComponent<Button>("Red");
			print (b);
			//btn.onClick.AddListener (() => onButtonClick (color));
			//if (GUILayout.Button(color + "Button", new GUILayoutOption())
			//	print(color);
			i++;
		};
		*/
	}

	// Use this for initialization
	void Start () {
		print (Screen.height);
		transform.Translate (new Vector2 (0, Screen.height / 2 - 30));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
