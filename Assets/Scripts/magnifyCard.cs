using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class magnifyCard : MonoBehaviour, IPointerExitHandler, IPointerUpHandler, IPointerEnterHandler, IPointerDownHandler {

	Material cardMaterial;
	GameObject canvas;
	string materialName;

	// Use this for initialization
	void Start () {
		cardMaterial = GetComponent<Renderer> ().material;
		canvas = GameObject.Find ("magnifyCard");
		materialName = cardMaterial.name.Remove(cardMaterial.name.Length - 11);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerEnter(PointerEventData data)
	{
		//if (!EventSystem.current.IsPointerOverGameObject (Input.GetTouch(0).fingerId)) {
			canvas.transform.GetChild (0).gameObject.SetActive (true);
			canvas.gameObject.transform.GetChild (0).GetComponent<UnityEngine.UI.Image> ().material = Resources.Load ("Materials/" + materialName, typeof(Material)) as Material;
		//}
	}

	public void OnPointerExit(PointerEventData data)
	{
		//if (!EventSystem.current.IsPointerOverGameObject (Input.GetTouch(0).fingerId)) {
			canvas.transform.GetChild (0).gameObject.SetActive (false);
		//}
	}

	public void OnPointerDown(PointerEventData data){
	}

	public void OnPointerUp(PointerEventData data)
	{
		//if (!EventSystem.current.IsPointerOverGameObject (Input.GetTouch(0).fingerId)) {
			canvas.transform.GetChild (0).gameObject.SetActive (false);
		//}
	}
}
