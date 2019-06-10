using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresstoOpen : MonoBehaviour {
	
	private DialogueManager dMAn;

	void Start(){
		
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKeyDown (KeyCode.E)) {
//		
//			if (ChestOpen.chest1) 
//			{
//				animo.SetBool ("isOpen", true);
//				//Destroy (ChestOpen.chest1);
//			}
	}
		void OnTriggerStay2D(Collider2D col)
		{
		if (col.gameObject.name == "Player") {
			if (Input.GetKeyUp (KeyCode.E)) {

			}
		}

			if (transform.parent.GetComponent<ChestOpen> () != null) {
			
				transform.parent.GetComponent<ChestOpen> ().canMove = false;
			}
//				
		}
	}
