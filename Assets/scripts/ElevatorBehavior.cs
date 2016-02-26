﻿using UnityEngine;
using System.Collections;

public class ElevatorBehavior : MonoBehaviour {

	public bool open = false;
	public Sprite openSprite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (open && openSprite != null) {
			GetComponent<SpriteRenderer>().sprite = openSprite;
			GetComponent<BoxCollider2D>().enabled = false;
	
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag.Equals ("Player")) {
			GameObject possessed = other.gameObject.GetComponent<PlayerPossession> ().possessed;
			if (possessed != null) {
				if (possessed.GetComponent<Enemy> ().enemyType == Enemy.EnemyType.Scientist) {
					open = true;
					if(this.gameObject.tag.Equals("Finish")){
						Application.LoadLevel("GameOver");
					}
				}
			}
		} else if (other.gameObject.tag.Equals ("Enemy")) {
			if (other.gameObject.GetComponent<Enemy>().enemyType == Enemy.EnemyType.Scientist){
				open = true;
			}
		
		}
	}
}