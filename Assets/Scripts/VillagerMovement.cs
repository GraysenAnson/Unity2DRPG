using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {
	
	Animator anim1;

	public float moveSpeed;

	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;

	private Rigidbody2D myRigidbody;

	public bool isWalking;
	public float walkTime;
	public float waitTime;
	private float walkCounter;
	private float waitCounter;

	private int WalkDirection;

	public Collider2D walkZone;
	private bool hasWalkZone;

	public bool canMove;
	private DialogueManager theDM;

	//private CameraFollow targetCamera;
	public Transform target;

	// Use this for initialization
	void Start () {

		//targetCamera = FindObjectOfType<CameraFollow> ();
		anim1 = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();

		theDM = FindObjectOfType<DialogueManager> ();

		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDirection ();

		if (walkZone != null) 
		{
			minWalkPoint = walkZone.bounds.min;
			maxWalkPoint = walkZone.bounds.max;
			hasWalkZone = true;
		}

		canMove = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (!theDM.dialogActive) {

			canMove = true;
		}

		if (!canMove) {

			transform.LookAt (target);
			myRigidbody.velocity = Vector2.zero;
			anim1.SetBool ("isWalking", false);

			return;
		}

		if (isWalking) {
			walkCounter -= Time.deltaTime;

			anim1.SetBool ("isWalking", true);

				
			switch (WalkDirection) {
			case 0:
				//north
				myRigidbody.velocity = new Vector2 (0, moveSpeed);

				anim1.SetFloat ("input_x", 0);
				anim1.SetFloat ("input_y", 1);

				if (hasWalkZone && transform.position.y > maxWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
					anim1.SetBool ("isWalking", false);
				}
				break;

			case 1:
				//East
				anim1.SetFloat ("input_x", 1);
				anim1.SetFloat ("input_y", 0);

				myRigidbody.velocity = new Vector2 (moveSpeed, 0);

				if (hasWalkZone && transform.position.x > maxWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
					anim1.SetBool ("isWalking", false);
				}
				break;

			case 2:
				//South
				anim1.SetFloat ("input_x", 0);
				anim1.SetFloat ("input_y", -1);

				myRigidbody.velocity = new Vector2 (0, -moveSpeed);

				if (hasWalkZone && transform.position.y < minWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
					anim1.SetBool ("isWalking", false);
				}
				break;

			case 3:
				//West
				anim1.SetFloat ("input_x", -1);
				anim1.SetFloat ("input_y", 0);

				myRigidbody.velocity = new Vector2 (-moveSpeed, 0);

				if (hasWalkZone && transform.position.x < minWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
					anim1.SetBool ("isWalking", false);
				}
				break;
			}

		if (walkCounter < 0) {
			isWalking = false;
			waitCounter = waitTime;
			}
		} 

		else {
			waitCounter -= Time.deltaTime;

			myRigidbody.velocity = Vector2.zero;
			anim1.SetBool ("isWalking", false);

			if (waitCounter < 0) {
				ChooseDirection ();
			}

		}
	}

	public void ChooseDirection(){
	
		WalkDirection = Random.Range (0, 4);
		isWalking = true;
		walkCounter = walkTime;
	}

}
