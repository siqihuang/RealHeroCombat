using UnityEngine;
using System.Collections;

public class globalTest : MonoBehaviour {
	public int heroPosition;
	public GameObject hero;
	// Use this for initialization
	void Start () {
		heroPosition = 0;
		Vector3 pos = new Vector3 (-5.5f, 0, 3.5f);
		hero=Instantiate(hero,pos,Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
