using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class attack : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler {

	Animator anim;
	GameObject attacker;
	Vector3 speed;
	Rigidbody rbody;
	bool running;
	bool attacking;
	Vector3 attackerOriginalPosition;
	Vector3 destination;
	Vector3 originalEulerangles;
	bool readyToCast;
	bool readyToAttack;
	float rotatedByDamage;
	float a, b;
	float distances;
	Vector3 backDirection;
	Vector3 camOriPos;
	Vector3 camOriAngles;
	public bool realBody;
	public AudioClip blastOut;
	public AudioClip explosion;
	public AudioClip kick;
	public AudioClip hurt;
	private bool exit;

	// Use this for initialization
	void Start () {
		readyToAttack = false;
		running = false;
		attacking = false;
		camOriPos = Camera.main.transform.position;
		camOriAngles = Camera.main.transform.eulerAngles;
		exit = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (running) {
			Camera.main.transform.position = attacker.transform.position - speed + new Vector3 (0, 2f, 0);
			Vector3 distance = this.transform.position - attacker.transform.position;
			distance.y = 0f;
			if (distance.magnitude < 1) {
				// Close enough. Stop running and start attacking.
				rbody.velocity = new Vector3 (0f, 0f, 0f);
				rbody.isKinematic = true;
				anim.Play ("WAIT04", -1, 0f);
				running = false;

				destination = attacker.transform.position;
				backDirection = attackerOriginalPosition - destination;
				distances = backDirection.magnitude;
				a = -10 / Mathf.Pow (distances / 2, 2);
				b = 20 / (distances / 2);
				GameObject.Find ("table").GetComponent<countMinions> ().destination = destination;
				GameObject.Find ("table").GetComponent<countMinions> ().backDirection = backDirection;
				GameObject.Find ("table").GetComponent<countMinions> ().distances = distances;
				GameObject.Find ("table").GetComponent<countMinions> ().a = a;
				GameObject.Find ("table").GetComponent<countMinions> ().b = b;
				GameObject.Find ("table").GetComponent<countMinions> ().attackerOriginalPosition = attackerOriginalPosition;
				GameObject.Find ("table").GetComponent<countMinions> ().originalEulerangles = originalEulerangles;
			}
		} else if (this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("JUMP00B")) {
			
			distances = GameObject.Find ("table").GetComponent<countMinions> ().distances;
			destination = GameObject.Find ("table").GetComponent<countMinions> ().destination;
			backDirection = GameObject.Find ("table").GetComponent<countMinions> ().backDirection;
			a = GameObject.Find ("table").GetComponent<countMinions> ().a;
			b = GameObject.Find ("table").GetComponent<countMinions> ().b;
			attackerOriginalPosition = GameObject.Find ("table").GetComponent<countMinions> ().attackerOriginalPosition;
			originalEulerangles = GameObject.Find ("table").GetComponent<countMinions> ().originalEulerangles;
			Camera.main.transform.position = camOriPos;
			Camera.main.transform.eulerAngles = camOriAngles;
			float jumpPercent;
			jumpPercent = this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime * distances;
			//Debug.Log (anim.GetCurrentAnimatorStateInfo (0).normalizedTime);
			float jumpX, jumpY, jumpZ;
			jumpX = jumpPercent * (backDirection.x / distances);
			jumpZ = jumpPercent * (backDirection.z / distances);
			jumpY = a * Mathf.Pow (jumpPercent, 2) + b * jumpPercent;
			jumpY /= 5f;
			this.transform.position = destination + new Vector3 (jumpX, jumpY, jumpZ);
			if (this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime > 0.95f) {
				this.transform.position = attackerOriginalPosition;
				this.transform.eulerAngles = originalEulerangles;
				GameObject.Find ("table").GetComponent<countMinions> ().attacking = false;
				attacking = false;
				GameObject.Find ("table").GetComponent<countMinions> ().hurtRealBody = true;
			}
		} 
		else if (tag == "friendly" && this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("DAMAGED00")) {
			if (this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime > 0.95f) {
				this.gameObject.SetActive (false);
				Camera.main.transform.position = camOriPos;
				Camera.main.transform.eulerAngles = camOriAngles;
				GameObject.Find ("table").GetComponent<countMinions> ().attacking = false;
				attacking = false;
				GameObject.Find ("table").GetComponent<countMinions> ().num_minions -= 1;
				int nameLength = name.Length;
				GameObject.Find ("table").GetComponent<countMinions> ().deadChan = (name [nameLength - 1] - '0');
				print (name [nameLength - 1] - '0');
			}
		}	

		if (Input.GetMouseButton (1) && (GameObject.Find ("table").GetComponent<countMinions> ().readyToAttack == true)) {
			GameObject.Find ("table").GetComponent<countMinions> ().readyToAttack = false;
			Camera.main.transform.position -= new Vector3 (4f, 0, 0);
		}
	}

	public void OnPointerDown(PointerEventData data){
		exit = false;
	}

	public void OnPointerExit(PointerEventData data){
		exit = true;
	}

	public void OnPointerUp(PointerEventData data){
		if (!exit) {
			readyToCast = GameObject.Find ("table").GetComponent<countMinions> ().readyToCast;
			readyToAttack = GameObject.Find ("table").GetComponent<countMinions> ().readyToAttack;
			attacking = GameObject.Find ("table").GetComponent<countMinions> ().attacking;
			if (readyToCast) {
				// A spell has been chosen. Try to get the animation of the spell.
				string spell;
				spell = GameObject.Find ("table").GetComponent<countMinions> ().spell;
				GameObject spellCard;
				spellCard = GameObject.Find (spell);
				spell = spellCard.tag;
				GameObject spellAnimation;
				spellAnimation = Resources.Load ("Prefab/" + spell + "Move", typeof(GameObject)) as GameObject;
				AudioSource.PlayClipAtPoint (blastOut, GameObject.Find ("table").transform.position);

				// Compute all the variables needed to instantiate the animation.
				Vector3 direction;
				direction = transform.position + GetComponent<CapsuleCollider> ().center - Camera.main.transform.position + new Vector3(0, 0.5f, 0) ;
				Quaternion rotation = Quaternion.LookRotation (direction);
				spellAnimation.transform.rotation = rotation;
				rotatedByDamage = spellAnimation.transform.eulerAngles.y;
				GetComponent<CapsuleCollider> ().isTrigger = false;
				GameObject.Instantiate (spellAnimation, Camera.main.transform.position - new Vector3(0, 0.5f, 0) , spellAnimation.transform.rotation);
				spellCard.gameObject.SetActive (false);
				GameObject.Find ("table").GetComponent<countMinions> ().num_cards -= 1;

			} 
			else if(!readyToAttack && tag == "friendly" && !attacking){
				Camera.main.transform.position += new Vector3 (4f, 0, 0);
				GameObject.Find ("table").GetComponent<countMinions> ().readyToAttack = true;
				GameObject.Find ("table").GetComponent<countMinions> ().attackerName = name;
			}
			else if(readyToAttack && tag == "enemy" && !attacking){
				GameObject.Find ("table").GetComponent<countMinions> ().attacking = true;
				GameObject.Find ("table").GetComponent<countMinions> ().readyToAttack = false;
				running = true;
				string attackerName;
				attackerName = GameObject.Find ("table").GetComponent<countMinions> ().attackerName;
				attacker = GameObject.Find (attackerName);
				anim = attacker.GetComponent<Animator> ();
				rbody = attacker.GetComponent<Rigidbody> ();
				rbody.isKinematic = false;
				attackerOriginalPosition = attacker.transform.position;
				originalEulerangles = attacker.transform.eulerAngles;

				// Compute the velocity of running.
				speed = this.transform.position - attacker.transform.position;
				speed.y = 0f;
				speed = speed.normalized;

				// Compute the angle that the character should turn.
				float angle;
				angle = Vector3.Angle (speed, new Vector3(1f, 0f, 0f));
				if (speed.z > 0) {
					attacker.transform.eulerAngles -= new Vector3 (0f, angle, 0f);
				} 
				else {
					attacker.transform.eulerAngles += new Vector3 (0f, angle, 0f);
				}

				//Play the animation of running and set the velocity.
				anim.Play ("RUN00_F", -1, 0f);
				speed.x = speed.x * 2f;
				speed.z = speed.z * 2f;
				rbody.velocity = speed;

				Camera.main.transform.eulerAngles = attacker.transform.eulerAngles + new Vector3(20f, 0, 0);
			}
		}
	}

	void OnTriggerEnter(Collider col){
		// Kicked by leg.
		if (col.tag == "leg") {
			Debug.Log (col.name);
			Vector3 originalAngle = transform.eulerAngles;
			Vector3 newAngle = col.transform.parent.parent.parent.parent.eulerAngles;
			transform.eulerAngles = newAngle + new Vector3 (0f, 180f, 0f);

			if (this.realBody == true) {
				this.GetComponent<healthBar> ().damageTaken = 0.2f;
				AudioSource.PlayClipAtPoint (kick, GameObject.Find ("table").transform.position);
			}
			else {
				attacker.GetComponent<Animator> ().SetTrigger("touchingDarkness");
				attacker.GetComponent<healthBar> ().damageTaken = 1.0f;
				AudioSource.PlayClipAtPoint (hurt, GameObject.Find ("table").transform.position);
			}
		} 
	}

	void OnParticleCollision(){
		AudioSource.PlayClipAtPoint (explosion, this.transform.position);
		if (this.realBody == true) {
			transform.eulerAngles = new Vector3 (0, rotatedByDamage + 180, 0);
			this.GetComponent<healthBar> ().damageTaken = 0.2f;
			this.GetComponent<healthBar> ().fireballCast = true;
		}
		GetComponent<CapsuleCollider> ().isTrigger = true;
		GameObject.Find ("table").GetComponent<countMinions> ().readyToCast = false;
		Camera.main.transform.position -= new Vector3 (4f, 0, 0);
	}
}
