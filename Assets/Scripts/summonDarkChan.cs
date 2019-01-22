using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonDarkChan : MonoBehaviour {

	public List<GameObject> enemy = new List<GameObject>();
	Vector3 center;
	bool gathering;
	bool scattering;
	float scatteringTime;
	float gatheringTime;
	List<Vector3> distance;

	// Use this for initialization
	void Start () {
		center = new Vector3 (2.3f, 4.607142f, 0);
		gathering = false;
		gatheringTime = 0.0f;
		scattering = false;
		scatteringTime = 0.0f;

		GameObject darkChan;
		darkChan = Resources.Load ("Prefab/unitychan", typeof(GameObject)) as GameObject;
		int num_darkChan;
		num_darkChan = GameObject.Find ("table").GetComponent<countMinions> ().num_darkChan;
		bool defineRealBody = false;
		for (int i = 1; i <= num_darkChan; i++) {
			GameObject cloneMinion;
			cloneMinion = GameObject.Instantiate (darkChan, new Vector3 (2.3f, 4.607142f, -0.8f + 1.6f * (i / 2) * Mathf.Pow(-1, i)), darkChan.transform.rotation);
			cloneMinion.name = "darkChan" + i;
			cloneMinion.tag = "enemy";
			cloneMinion.transform.eulerAngles += new Vector3 (0, 180.0f, 0);
			if (!defineRealBody) {
				if (Random.value < (1.0f / num_darkChan)) {
					cloneMinion.GetComponent<attack> ().realBody = true;
					defineRealBody = true;
				} 
				else if (i == num_darkChan) {
					cloneMinion.GetComponent<attack> ().realBody = true;
				} 
				else {
					cloneMinion.GetComponent<attack> ().realBody = false;
				}
			}
			enemy.Add (cloneMinion);
			Debug.Log (cloneMinion.GetComponent<attack> ().realBody);
		}	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("table").GetComponent<countMinions> ().hurtRealBody) {
			GameObject.Find ("table").GetComponent<countMinions> ().hurtRealBody = false;
			int size = enemy.Count;
			distance = new List<Vector3>();
			for (int i = 0; i < size; i++) {
				distance.Add(center - enemy [i].transform.position);
				enemy [i].GetComponent<Collider> ().enabled = false;

				if ((size / 2) != (size / 2.0f) && i == 0) {
					continue;
				}
				enemy[i].GetComponent<Animator>().Play ("RUN00_F", -1, 0f);

				Quaternion rotation = Quaternion.LookRotation (distance[i]);
				enemy[i].transform.rotation = rotation;
			}
			gathering = true;
		}
		// Gather all the dark Chan together once the real body has been attacked.
		if (gathering) {
			gatheringTime += Time.deltaTime;
			if (gatheringTime < 1.0f) {
				int size = enemy.Count;
				for (int i = 0; i < enemy.Count; i++) {
					if ((size / 2) != (size / 2.0f) && i == 0) {
						continue;
					}
					enemy [i].transform.position += distance [i] * Time.deltaTime / 1.0f;
				}
			} 
			else {
				gathering = false;
				gatheringTime = 0;
				// Remove a random clone.
				for (int i = 0; i < enemy.Count; i++) {
					if (!enemy [i].GetComponent<attack> ().realBody) {
						enemy [i].gameObject.SetActive (false);
						enemy.RemoveAt (i);
						break;
					}
				}
				// Obtain the health of real body.
				float health = 0;
				for (int i = 0; i < enemy.Count; i++) {
					if (enemy [i].GetComponent<attack> ().realBody) {
						health = enemy [i].GetComponent<healthBar> ().health;
						break;
					}
				}
				// Set the health to all clones.
				for (int i = 0; i < enemy.Count; i++) {
					if (!enemy [i].GetComponent<attack> ().realBody) {
						enemy [i].GetComponent<healthBar> ().health = health;
					}
				}
				// Compute the velocity for the rest of the dark Chan.
				distance = new List<Vector3>();
				int size = enemy.Count;
				if ((size / 2) == (size / 2.0f)) {
					for (int i = 1; i <= size; i++) {
						distance.Add (new Vector3 (2.3f, 4.607142f, -0.8f + 1.6f * (i / 2) * Mathf.Pow (-1, i)) - center);
					}
					if (enemy [0].GetComponent<attack> ().realBody) {
						enemy [0].GetComponent<Animator>().Play ("RUN00_F", -1, 0f);
						Quaternion rotation = Quaternion.LookRotation (distance[0]);
						enemy[0].transform.rotation = rotation;
					}
				} 
				else {
					enemy [0].GetComponent<Animator>().Play ("WAIT00", -1, 0f);
					enemy [0].transform.eulerAngles = new Vector3 (0, -90.0f, 0);
					for (int i = 1; i <= size; i++) {
						distance.Add (new Vector3 (2.3f, 4.607142f, 1.6f * (i / 2) * Mathf.Pow (-1, i)) - center);
					}
				}
				scattering = true;
			}
		}
		// Rearrange the position for the rest of the dark Chan.
		if (scattering) {
			scatteringTime += Time.deltaTime;
			if (scatteringTime < 1.0f) {
				for (int i = 0; i < enemy.Count; i++) {
					enemy [i].transform.position += distance [i] * Time.deltaTime / 1.0f;
				}
			} 
			else {
				scattering = false;
				scatteringTime = 0;
				for (int i = 0; i < enemy.Count; i++) {
					enemy [i].GetComponent<Collider> ().enabled = true;
					enemy [i].transform.eulerAngles = new Vector3 (0, -90.0f, 0);
					enemy [i].GetComponent<Animator>().Play ("WAIT00", -1, 0f);
				}
			}
		}
	}
}
