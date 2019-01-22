using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countMinions : MonoBehaviour {

	public int num_minions;
	public int num_darkChan;
	public string spell;
	public string attackerName;
	public bool readyToCast;
	public bool readyToAttack;
	public bool attacking;
	public Vector3 destination;
	public Vector3 backDirection;
	public float distances;
	public float a, b;
	public Vector3 attackerOriginalPosition;
	public Vector3 originalEulerangles;
	GameObject canvas;
	public bool hurtRealBody;
	public bool[] slot = {false, false, false};
	public int deadChan;
	bool showWin;
	bool showLose;
	public int num_cards;
	public AudioClip beatLevel;
	public AudioClip gameover;

	// Use this for initialization
	void Start () {
		num_minions = 0;
		readyToCast = false;
		readyToAttack = false;
		attacking = false;
		canvas = GameObject.Find ("Canvas");
		num_darkChan = 4;
		hurtRealBody = false;
		deadChan = -1;
		showWin = false;
		showLose = false;
		num_cards = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (readyToCast || readyToAttack) {
			canvas.transform.GetChild (0).gameObject.SetActive (false);
			canvas.transform.GetChild (1).gameObject.SetActive (true);
		} else if (!attacking) {
			canvas.transform.GetChild (0).gameObject.SetActive (true);
			canvas.transform.GetChild (1).gameObject.SetActive (false);
		} 
		else {
			canvas.transform.GetChild (0).gameObject.SetActive (false);
			canvas.transform.GetChild (1).gameObject.SetActive (false);
		}
		if (deadChan != -1) {
			print (deadChan);
			slot [deadChan] = false;
			deadChan = -1;
		}
		if (!showWin) {
			if (this.GetComponent<summonDarkChan> ().enemy.Count == 1 && !attacking) {
				canvas.transform.GetChild (6).gameObject.SetActive (true);
				this.GetComponent<AudioSource> ().volume = 0;
				AudioSource.PlayClipAtPoint (beatLevel,gameObject.transform.position, 0.3f);
				showWin = true;
			}
		}
		if (!showLose) {
			if (this.GetComponent<summonDarkChan> ().enemy.Count >= 1 && num_cards == 0) {
				for (int i = 0; i < slot.Length; i++) {
					if (slot [i] == true) {
						break;
					}
					if (i == (slot.Length - 1)) {
						canvas.transform.GetChild (7).gameObject.SetActive (true);
						this.GetComponent<AudioSource> ().volume = 0;
						AudioSource.PlayClipAtPoint (gameover,gameObject.transform.position, 0.3f);
						showLose = true;
					}
				}
			}
		}

	}
}
