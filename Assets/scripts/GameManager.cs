using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {
	//Map
	[SerializeField] private GameObject pathfinder;

	//Paused 
	private bool paused;
	[SerializeField] private GameObject pauseGUI;

	//Singleton
	private static GameManager instance;
	public static GameManager Instance { get { return instance; } private set { } }

	//State
	public int level = 1;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (instance);
		instance = this;
	
	}

	void Start() {

		//Instantiate (pathfinder, transform.position, transform.rotation);
		paused = false;
		pauseGUI.GetComponent<Canvas>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!paused && Input.GetButtonDown ("Cancel")) {
			Pause ();
		} else if (paused && Input.GetButtonDown ("Cancel")) {
			UnPause ();
		} else if (paused && Input.GetButtonDown ("Submit")) {
			Quit ();
		}

	
	}

	void Pause (){
		paused = true;
		pauseGUI.GetComponent<Canvas> ().enabled = true;
		Time.timeScale = 0f;

	}

	void UnPause(){
		paused = false;
		pauseGUI.GetComponent<Canvas> ().enabled = false;
		Time.timeScale = 1f;
	}

	public void Quit(){
		paused = false;
		Application.LoadLevel ("MainMenu");
	}

	public void NextLevel(){
		level ++;
		string nextLevel = ("Level_" + level);
		print ("Loading... " + nextLevel);
		Application.LoadLevel (nextLevel);
	}
}
