using UnityEngine;
using System.Collections;

public class colorTest : MonoBehaviour {
	public Material yellow,green;
	// Use this for initialization
	void Start () {
		renderer.material = yellow;
	}
	
	// Update is called once per frame
	void Update(){
	}

	void OnMouseDown(){
		renderer.material = green;
		//renderer.material.color.a = 0.5f;
	}
}