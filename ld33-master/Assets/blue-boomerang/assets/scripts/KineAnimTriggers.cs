using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class KineAnimTriggers : MonoBehaviour {


	string olddir;
	string dir;
	public Animator anim;
	private Vector3 lastPosition = Vector3.zero;
	//public bool spider;
	// Use this for initialization
	 void OnStart () {

		anim = this.gameObject.GetComponent<Animator>();
		olddir = "idle";
		dir = "down";
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 velocity = (this.transform.position - lastPosition) / Time.deltaTime;
		lastPosition = this.transform.position;
		PickDirection (velocity);

	}

	void PickDirection (Vector3 vel){

		if (GetComponent<SimpleAI2D>()){
			dir = GetComponent<SimpleAI2D>().facing.ToString();
			SetNewStates(dir);
		}
		else{

			if (Mathf.Abs (vel.x) >= 0.5f || Mathf.Abs (vel.y) >= 0.5f) {
				//anim.ResetTrigger("idle");

				if (Mathf.Abs (vel.x) > Mathf.Abs (vel.y)) {
					if (vel.x >= 0.5f) {
						dir = "right";
					} else if (vel.x < 0.5f) {
						dir = "left";
					}

				} else {
					if (vel.y >= 0.2f) {
						dir = "up";
					} else if (vel.y <= -1f*0.2f){
						dir = "down";
					}
					else { 
						dir = "down";
					}
				}

			
			} else{

				anim.SetTrigger("idle"); //sets idle bool
			}
			if (dir != "") {
				// if last direction is different from new, set triggers in animationcontroller
				anim.SetTrigger (dir);
			} else {
				anim.SetTrigger("idle");
			}

			olddir = dir;
			/* // speed debug
			if (gameObject.GetComponentInParent<PlayerMobility>()) {
				Debug.Log ("player moves" + dir);
				Debug.Log("player speed x" + vel.x);
				Debug.Log ("player speed y" + vel.y);
			
			}*/

		}
	}
	void SetNewStates (string dirSend){

	
		anim.SetTrigger (dirSend);

	}
	public void NPCattack(){

		// set bool or trigger for attack + dir?
		anim.SetTrigger ("attack");
		anim.SetBool("idle",false);

	}
	public void Possess(){
		if (gameObject.GetComponentInParent<PlayerMobility> ()) {
			anim.SetTrigger("possession");
			anim.SetBool("idle", false);
		}

	}

}
