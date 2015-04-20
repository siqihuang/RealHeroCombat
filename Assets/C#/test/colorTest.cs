using UnityEngine;
using System.Collections;

public class colorTest : MonoBehaviour {
	public Material yellow,green;
	public int ID;
	public int state;
	public GameObject player;
	// Use this for initialization
	void Start () {
		renderer.material = yellow;
		state = 0;
	}
	
	// Update is called once per frame
	void Update(){
	}

	void OnMouseDown(){
		//renderer.material = green;
		//renderer.material.color.a = 0.5f;
		if (state == 1) {//activated
			player=GameObject.Find("Hero_1(Clone)");
			playerTest test=player.GetComponent<playerTest>();
			test.target=ID;
			test.state=2;
		}
	}

	public void changeColor(int color){
		if(color==0) renderer.material = yellow;
		else renderer.material = green;
	}
}