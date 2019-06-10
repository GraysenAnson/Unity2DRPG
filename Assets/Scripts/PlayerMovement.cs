using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	//public NPC_STOP vMove;
	Rigidbody2D rbody;
	Animator anim;

	//private float moveS = 2;
	public bool canMove;


	// Use this for initialization
	void Start () {

		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();


	}
	
	// Update is called once per frame
	void Update () {

		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;

		//When talking to an NPC/chest, the player will not be able to move.
		if (!canMove) {
			//Stops all NPCS from moving when character is stationary in a chat or event
			//vMove.canMove = false;

			anim.SetBool ("isWalking", false);
			anim.SetBool ("isRun", false);

			//Vector2 movement_Vector = new Vector2 (Input.GetAxisRaw (""), Input.GetAxisRaw (""));
			rbody.velocity = new Vector2 (movement_vector.x * 0, movement_vector.y * 0); 

			movement_vector = Vector2.zero;
			return;
		}

		if (Input.GetKey (KeyCode.LeftShift)) {

			if (movement_vector != Vector2.zero) {

				anim.SetBool ("isRun", true);
				anim.SetBool ("isWalking", false);
				//we want to keep facing the way they are after walking
				anim.SetFloat ("input_X", movement_vector.x);
				anim.SetFloat ("input_Y", movement_vector.y);

			} else {
				anim.SetBool ("isRun", false);
				anim.SetBool ("isWalking", false);
			}
			rbody.velocity = new Vector2 (movement_vector.x * 2, movement_vector.y * 2);
			return;

		}


		if (movement_vector != Vector2.zero) {

			anim.SetBool ("isWalking", true);
			anim.SetBool ("isRun", false);
			//we want to keep facing the way they are after walking
			anim.SetFloat ("input_X", movement_vector.x);
			anim.SetFloat ("input_Y", movement_vector.y);

		} else {
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isRun", false);
		}
			
		//This one had an issue in the build version. rkm2dev video
		//rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime * 2);

		rbody.velocity = new Vector2 (movement_vector.x * 1, movement_vector.y * 1);
		return;
	}
}
