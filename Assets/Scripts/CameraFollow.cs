using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	//stores the position data, scale data and rotation data
	public Transform target;

	//gives us a reference for the camera
	Camera mycam;

	//public variable to control the camera speed
	public float m_speed = 0.1f;

	// Use this for initialization
	void Start () {

		mycam = GetComponent<Camera> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		//Scales the game to a screen size of for every 32 pixles it doubles it and presents taht on the screen. The f stands for a floating point.
		mycam.orthographicSize = (Screen.height / 100f) / 4f;

		if (target) {
		
			//Lerp is for linar eterpatation i think it's called?
			transform.position = Vector3.Lerp(transform.position, target.position, m_speed) + new Vector3(0, 0, -10);

		}


	}
}
