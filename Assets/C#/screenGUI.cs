using UnityEngine;
using System.Collections;

public class screenGUI : MonoBehaviour {
	public Texture2D move,attack,wait;
	public Hero_1 hero;
	public PlayerMovement playerMovement;
	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.Find ("Hero_1");
		hero = obj.GetComponent<Hero_1> ();
		playerMovement = hero.GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GUI.Button (new Rect (15, 150, 50, 50), move)) {
			playerMovement.TestMove(true);
		}
		if (GUI.Button (new Rect (15, 210, 50, 50), attack)) {
			playerMovement.TestAttack();
		}
		if (GUI.Button (new Rect (15, 270, 50, 50), wait)) {
			playerMovement.TestMove(false);
		}
	}


}
