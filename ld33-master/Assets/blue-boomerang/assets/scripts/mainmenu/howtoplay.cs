﻿using UnityEngine;
using System.Collections;

public class howtoplay : menu {

	[SerializeField] public string loadMe;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
			if (selection == 0) {
				Application.LoadLevel(loadMe);
			}
		}
		
		if (selection == 0) {
			arrow.transform.position = new Vector3(-3f, -2.5f, 0);
		} 
	}
}
