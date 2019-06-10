using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogChestHolder : MonoBehaviour {

	public string dialogue;
	private DialogueManager dMAn;
	private int countE;

	public string[] dialogueLines;

	// Use this for initialization
	void Start () {
		dMAn = FindObjectOfType<DialogueManager> ();
	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (countE <= 0) {
			if (other.gameObject.name == "Player") {
				if (Input.GetKeyUp (KeyCode.E)) {
					//dMAn.ShowBox (dialogue);

					if (!dMAn.dialogActive) {

						dMAn.dialogLines = dialogueLines;
						dMAn.currentLine = 0;
						dMAn.ShowDialogue ();
					}

					if (transform.parent.GetComponent<ChestOpen> () != null) {
						transform.parent.GetComponent<ChestOpen> ().canMove = false;
					}
					countE++;

				}

			}
		}
	}
}