using UnityEngine;
using System.Collections;

public class clickTest1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		// this object was clicked - do something
		Debug.Log ("This is 2");
		//Destroy (this.gameObject);
	}  
}
