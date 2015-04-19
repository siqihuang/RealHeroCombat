using UnityEngine;
using System.Collections;
using Vuforia;

public class playerTest : MonoBehaviour, ITrackableEventHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus){
	}
}
