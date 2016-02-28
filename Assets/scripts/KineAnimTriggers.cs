using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class KineAnimTriggers : MonoBehaviour {


	string olddir;
	string dir;
	[SerializeField] private Animator anim;
	[SerializeField] private Vector3 lastPosition = Vector3.zero;


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

		if (this.GetComponent<SimpleAI2D>()){
			dir = GetComponent<SimpleAI2D>().facing.ToString();
			SetNewStates(dir);
		}
		else{

			if (Mathf.Abs (vel.x) >= 0.5f || Mathf.Abs (vel.y) >= 0.5f) {
				//anim.ResetTrigger("idle");

				if (Mathf.Abs (vel.x) > Mathf.Abs (vel.y)) {
					if (vel.x >= 0.2f) {
						dir = "right";
					} else if (vel.x < 0.2f) {
						dir = "left";
					}

				} else {
					if (vel.y >= 0.1f) {
						dir = "up";
					} else if (vel.y <= -1f*0.1f){
						dir = "down";
					}
					else { 
						dir = "down";
					}
				}

			
			} else{

				dir = ("idle"); //sets idle bool
			}
			//Debug.Log (this.gameObject.name + dir);
		
		}
		SetNewStates(dir);
	}
	public void SetNewStates (string dirSend){

		this.anim.SetTrigger (dirSend);
		olddir = dirSend;
		if (olddir == "idle") {
			this.anim.ResetTrigger("idle");
		}

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
