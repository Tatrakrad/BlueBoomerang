using UnityEngine;
using System.Collections;

public class PlayerMobility : MessageBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float xAxis;
	[SerializeField] private float yAxis;

	public bool monsterDead = false;

	void Update () {
		xAxis = Input.GetAxis ("Horizontal");
		yAxis = Input.GetAxis ("Vertical");
	}	

	void FixedUpdate(){ 

		if (monsterDead == false) {
			Move (xAxis, yAxis);
			
		} else {
			GetComponent<SpriteRenderer>().color = Color.red;
		} 

		// Always point the player towards the cursor.
//		var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//		transform.rotation = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

		// To keep the rotation from skewing.
//		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
	}

	public void Die() {
	
		// If you are possessing someone, they die before you do.
		if (GetComponent<PlayerPossession>().possessed != null) {
			GetComponent<PlayerPossession>().EjectPossessedBody(false);
		} else {
			monsterDead = true;
		}

		Invoke("GoToMainMenu", 3.0f);

	}

	void GoToMainMenu() {
		Application.LoadLevel("MainMenu");
	}

	protected override void OnStart () {
	
	}


	void Move(float hor, float ver){

		transform.Translate(new Vector3(hor * speed, 0, 0), Space.World);
		transform.Translate(new Vector3(0, ver * speed, 0), Space.World);

	}

}

