using UnityEngine;
using System.Collections;
using Vuforia;

public class screenGUI : MonoBehaviour,ITrackableEventHandler {
	public Texture2D move,attack,wait,s1,s2,s3;
	public Hero_1 hero;
	public PlayerMovement playerMovement;
	public GameObject playerTrack;
	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.Find ("Hero_1");
		hero = obj.GetComponent<Hero_1> ();
		playerMovement = hero.GetComponent<PlayerMovement> ();

		playerTrack = GameObject.Find ("ImageTarget1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		if (GUI.Button (new Rect (15, 150, 50, 50), move)){
			playerMovement.TestMove(true);
			//playerTrack.SetActive(true);
		}
		if (GUI.Button (new Rect (15, 210, 50, 50), attack)) {
			playerMovement.TestAttack();
		}
		if (GUI.Button (new Rect (15, 270, 50, 50), wait)) {
			playerMovement.TestMove(false);
			//playerTrack.SetActive(false);
		}

		if (GUI.Button (new Rect (700, 150, 50, 50), s1))
		{
			hero.UseSkill(1);
		}

		if (GUI.Button (new Rect (700, 210, 50, 50), s2)) 
		{
			hero.UseSkill(2);
		}

		if (GUI.Button (new Rect (700, 270, 50, 50), s3)) 
		{
			hero.UseSkill(3);
		}
	}

	public void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus){
	}
}
