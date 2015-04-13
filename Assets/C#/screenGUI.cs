using UnityEngine;
using System.Collections;

public class screenGUI : MonoBehaviour {
	public Texture2D move,attack,wait;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Button (new Rect (15, 150, 50, 50), move);
		GUI.Button (new Rect (15, 210, 50, 50), attack);
		GUI.Button (new Rect (15, 270, 50, 50), wait);
	}
}
