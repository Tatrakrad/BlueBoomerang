using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Singleton
	private static GameManager instance;
	public static GameManager Instance { get { return instance; } private set { } }

	// Use this for initialization
	void Awake () {

		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
