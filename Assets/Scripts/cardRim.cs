using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class cardRim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData data)
	{
		//if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)){
			this.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.13f);
		//}
	}

	public void OnPointerExit(PointerEventData data)
	{
		//if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)){
			this.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.0f);
		//}
	}
}
