using UnityEngine;
using System.Collections;

public class collisionTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collider){
		Debug.Log ("in collision");
	}
}
