using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour {

	public float health = 1.0f;
	public float damageTaken = 0.0f;
	GameObject bar;
	public bool fireballCast;

	// Use this for initialization
	void Start () {
		bar = this.transform.Find ("HealthBar/Health").gameObject;
		fireballCast = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Scale the health bar.
		health -= damageTaken;
		if (health > 0 && health < 0.0001f) {
			this.GetComponent<Animator>().Play ("DAMAGED01", -1, 0f);
			health = 0;
		} else if (damageTaken != 0) {
			this.GetComponent<Animator>().Play ("DAMAGED00", -1, 0f);
		}
		if (this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("DAMAGED01")) {
			if (this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime > 0.5f) {
				this.gameObject.SetActive (false);
			}
		}
		if (fireballCast && this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("DAMAGED00")) {
			if (this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime > 0.95f) {
				GameObject.Find ("table").GetComponent<countMinions> ().hurtRealBody = true;
				fireballCast = false;
			}
		}
		damageTaken = 0;
		bar.transform.localScale = new Vector3 (health, bar.transform.localScale.y, bar.transform.localScale.z);

		// Rotate the health bar to let it always face the camera.
		Vector3 relativePos = Camera.main.transform.position - bar.transform.parent.position;
		Quaternion rotation = Quaternion.LookRotation (relativePos);
		bar.transform.parent.rotation = rotation;
	}
}
