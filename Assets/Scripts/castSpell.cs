using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class castSpell : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler {

	private bool exit;

	// Use this for initialization
	void Start () {
		exit = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1) && (GameObject.Find ("table").GetComponent<countMinions> ().readyToCast == true)) {
			GameObject.Find ("table").GetComponent<countMinions> ().readyToCast = false;
			Camera.main.transform.position -= new Vector3 (4f, 0, 0);
		}
	}

	public void OnPointerDown(PointerEventData data){
		exit = false;
	}

	public void OnPointerUp(PointerEventData data){
		if(!exit){
			if (!GameObject.Find ("table").GetComponent<countMinions> ().attacking) {
				Camera.main.transform.position += new Vector3 (4f, 0, 0);
				GameObject.Find ("table").GetComponent<countMinions> ().spell = name;
				GameObject.Find ("table").GetComponent<countMinions> ().readyToCast = true;
			}	
		}
	}

	public void OnPointerExit(PointerEventData data){
		exit = true;
	}
}
