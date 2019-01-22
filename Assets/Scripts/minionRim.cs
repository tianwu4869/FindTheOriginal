using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class minionRim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	void Start(){
		GameObject bodypart;
		if (this.tag == "enemy") {
			bodypart = this.transform.Find ("mesh_root/tail").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0.7f, 0, 0, 1));
			bodypart = this.transform.Find ("mesh_root/tail_bottom").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0.7f, 0, 0, 1));
			bodypart = this.transform.Find ("mesh_root/hair_front").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0.7f, 0, 0, 1));
			bodypart = this.transform.Find ("mesh_root/hair_frontside").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0.7f, 0, 0, 1));

			bodypart = this.transform.Find ("mesh_root/Leg").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0.7f, 0, 0, 1));
			bodypart.GetComponent<Renderer> ().material.SetVector ("_Color", new Vector4 (0, 0, 0, 1));
			bodypart = this.transform.Find ("mesh_root/Shirts").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0.7f, 0, 0, 1));
			bodypart.GetComponent<Renderer> ().material.SetVector ("_Color", new Vector4 (0, 0, 0, 1));
			bodypart = this.transform.Find ("mesh_root/hairband").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0.7f, 0, 0, 1));
			bodypart.GetComponent<Renderer> ().material.SetVector ("_Color", new Vector4 (0, 0, 0, 1));
			bodypart = this.transform.Find ("mesh_root/shirts_sode").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0.7f, 0, 0, 1));
			bodypart.GetComponent<Renderer> ().material.SetVector ("_Color", new Vector4 (0, 0, 0, 1));
			bodypart = this.transform.Find ("mesh_root/shirts_sode_BK").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0.7f, 0, 0, 1));
			bodypart.GetComponent<Renderer> ().material.SetVector ("_Color", new Vector4 (0, 0, 0, 1));
			bodypart = this.transform.Find ("mesh_root/uwagi").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0.7f, 0, 0, 1));
			bodypart.GetComponent<Renderer> ().material.SetVector ("_Color", new Vector4 (0, 0, 0, 1));
			bodypart = this.transform.Find ("mesh_root/uwagi_BK").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0.7f, 0, 0, 1));
			bodypart.GetComponent<Renderer> ().material.SetVector ("_Color", new Vector4 (0, 0, 0, 1));
			bodypart = this.transform.Find ("mesh_root/hair_accce").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0.7f, 0, 0, 1));
			bodypart.GetComponent<Renderer> ().material.SetVector ("_Color", new Vector4 (0, 0, 0, 1));
		} 
		else if (this.tag == "friendly") {
			bodypart = this.transform.Find ("mesh_root/tail").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0, 0.7f, 0, 1));
			bodypart = this.transform.Find ("mesh_root/tail_bottom").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0, 0.7f, 0, 1));
			bodypart = this.transform.Find ("mesh_root/hair_front").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0, 0.7f, 0, 1));
			bodypart = this.transform.Find ("mesh_root/hair_frontside").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0, 0.7f, 0, 1));

			bodypart = this.transform.Find ("mesh_root/Leg").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0, 0.7f, 0, 1));
			bodypart = this.transform.Find ("mesh_root/Shirts").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0, 0.7f, 0, 1));
			bodypart = this.transform.Find ("mesh_root/hairband").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0, 0.7f, 0, 1));
			bodypart = this.transform.Find ("mesh_root/shirts_sode").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0, 0.7f, 0, 1));
			bodypart = this.transform.Find ("mesh_root/shirts_sode_BK").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0, 0.7f, 0, 1));
			bodypart = this.transform.Find ("mesh_root/uwagi").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0, 0.7f, 0, 1));
			bodypart = this.transform.Find ("mesh_root/uwagi_BK").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0, 0.7f, 0, 1));
			bodypart = this.transform.Find ("mesh_root/hair_accce").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetVector ("_OutlineColor", new Vector4 (0, 0.7f, 0, 1));
		}

	}

	public void OnPointerEnter(PointerEventData data)
	{
		//if(!EventSystem.current.IsPointerOverGameObject()){
			GameObject bodypart;
			bodypart = this.transform.Find ("mesh_root/tail").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.10f);
			bodypart = this.transform.Find ("mesh_root/tail_bottom").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.10f);
			bodypart = this.transform.Find ("mesh_root/hair_front").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.10f);
			bodypart = this.transform.Find ("mesh_root/hair_frontside").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.10f);

			bodypart = this.transform.Find ("mesh_root/Leg").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.10f);
			bodypart = this.transform.Find ("mesh_root/Shirts").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.10f);
			bodypart = this.transform.Find ("mesh_root/hairband").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.10f);
			bodypart = this.transform.Find ("mesh_root/shirts_sode").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.10f);
			bodypart = this.transform.Find ("mesh_root/shirts_sode_BK").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.10f);
			bodypart = this.transform.Find ("mesh_root/uwagi").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.10f);
			bodypart = this.transform.Find ("mesh_root/uwagi_BK").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.10f);
			bodypart = this.transform.Find ("mesh_root/hair_accce").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.10f);
		//}
	}

	public void OnPointerExit(PointerEventData data)
	{
		//if(!EventSystem.current.IsPointerOverGameObject()){
			GameObject bodypart;
			bodypart = this.transform.Find ("mesh_root/tail").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.0f);
			bodypart = this.transform.Find ("mesh_root/tail_bottom").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.0f);
			bodypart = this.transform.Find ("mesh_root/hair_front").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.0f);
			bodypart = this.transform.Find ("mesh_root/hair_frontside").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.0f);

			bodypart = this.transform.Find ("mesh_root/Leg").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.0f);
			bodypart = this.transform.Find ("mesh_root/Shirts").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.0f);
			bodypart = this.transform.Find ("mesh_root/hairband").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.0f);
			bodypart = this.transform.Find ("mesh_root/shirts_sode").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.0f);
			bodypart = this.transform.Find ("mesh_root/shirts_sode_BK").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.0f);
			bodypart = this.transform.Find ("mesh_root/uwagi").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.0f);
			bodypart = this.transform.Find ("mesh_root/uwagi_BK").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.0f);
			bodypart = this.transform.Find ("mesh_root/hair_accce").gameObject;
			bodypart.GetComponent<Renderer> ().material.SetFloat ("_OutlineWidth", 1.0f);
		//}
	}
}
