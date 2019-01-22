using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour {

	Camera ViewofPlayer;
	float newx;
	float newy;
	float sensitivity;

	// Use this for initialization
	void Start () {
		ViewofPlayer = GetComponent<Camera> ();
		sensitivity = 2.0f;
		newx = transform.eulerAngles.x;
		newy = transform.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			Cursor.lockState = CursorLockMode.Locked;
			rotate ();
		}
		if (Input.GetMouseButtonUp (1)) {
			Cursor.lockState = CursorLockMode.None;
		}
	}

	void rotate(){
		newx += Input.GetAxis ("Mouse Y") * sensitivity;
		newy -= Input.GetAxis ("Mouse X") * sensitivity;
		transform.eulerAngles = new Vector3 (newx, newy, 0);
	}
		
}
