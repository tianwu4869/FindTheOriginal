using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class summonMinion : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler{
	GameObject card;
	GameObject minion;
	GameObject cloneMinion;
	public bool[] slot;
	private bool exit;

	// Use this for initialization
	void Start ()
	{
		exit = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void OnPointerUp(PointerEventData data)
	{
		if(!exit){
			if (this.tag == "minion") {
				GameObject.Find ("table").GetComponent<countMinions> ().num_cards -= 1;
				int num_minions;
				num_minions = GameObject.Find ("table").GetComponent<countMinions> ().num_minions;
				num_minions++;
				GameObject.Find ("table").GetComponent<countMinions> ().num_minions = num_minions;

				minion = Resources.Load ("Prefab/unitychan", typeof(GameObject)) as GameObject;
				GameObject tempObject = GameObject.Find (minion.name + "1");
				int numForName = 1;
				while (tempObject != null) {
					numForName++;
					tempObject = GameObject.Find (minion.name + numForName);
				}
				slot = GameObject.Find ("table").GetComponent<countMinions> ().slot;
				for (int i = 0; i < 3; i++) {
					if (slot [i] == false) {
						cloneMinion = GameObject.Instantiate (minion, new Vector3 (-4f, 4.607142f, 1.2f * ((i + 1) / 2) * Mathf.Pow (-1, (i + 1))), minion.transform.rotation);
						cloneMinion.name = minion.name + i;
						slot [i] = true;
						break;
					}
				}
				Debug.Log (string.Format ("{0} {1} {2}", slot [0], slot [1], slot [2]));
				GameObject.Find ("table").GetComponent<countMinions> ().slot = slot;
				minion = null;
				this.gameObject.SetActive (false);
			}
		}
	}

	public void OnPointerDown(PointerEventData data){
		exit = false;
	}

	public void OnPointerExit(PointerEventData data){
		exit = true;
	}
}
