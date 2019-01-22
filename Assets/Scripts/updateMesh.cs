using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateMesh : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Mesh mesh;
		mesh = GetComponent<MeshFilter>().sharedMesh;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals ();
		mesh.RecalculateTangents ();
		GetComponent<MeshCollider>().sharedMesh = mesh;
	}
}
