using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour{
	Animator animo;
	public bool canMove;
	private DialogueManager theDM;


	void Start(){
		animo = GetComponent<Animator> ();
		theDM = FindObjectOfType<DialogueManager> ();

	}
//
	void Update(){

		if (!theDM.dialogActive) {
			canMove = true;
		}


		if (!canMove) {
			animo.SetBool ("isOpen", true);
			return;
		}

	} 

}