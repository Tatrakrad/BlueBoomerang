using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {
	//Map
	[SerializeField] private GameObject pathfinder;

	//Singleton
	private static GameManager instance;
	public static GameManager Instance { get { return instance; } private set { } }

	// Use this for initialization
	void Awake () {

		instance = this;
	}

	void Start() {

		//Instantiate (pathfinder, transform.position, transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Cancel")) {
			Application.Quit();
		}
	
	}
}
