using UnityEngine;
using System.Collections;

public class ReactorCore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag.Equals ("Player")) {

			Debug.Log("You Win");
		
		}

	}
}
