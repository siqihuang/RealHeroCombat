using UnityEngine;
using System.Collections;
using Vuforia;

public class VideoBackgroundOff : MonoBehaviour, ITrackerEventHandler {
	
	private bool mQCARInited = false;
	
	// Use this for initialization
	void Start () {     
		// Register this class as ITrackerEventHandler 
		// for the QCARBehaviour
		QCARBehaviour qcar = GetComponentInChildren<QCARBehaviour>();
		if (qcar) {
			qcar.RegisterTrackerEventHandler(this);
		}
	}

	public void OnInitialized() {
		mQCARInited = true;
		
		// As soon as QCAR has initialized
		// switch off camera video background rendering
		//QCARRenderer.Instance.DrawVideoBackground = false;
	}
	
	// Implement OnTrackablesUpdated() method of
	// the ITrackerEventHandler interface
	public void OnTrackablesUpdated() {
		// do nothing
	}

	void onApplicationPause (bool paused) {
		bool resumed = !paused;
		if (resumed && mQCARInited) {
			// App was resumed,
			// make sure the camera video background rendering is OFF
			//QCARRenderer.Instance.DrawVideoBackground = false;
		}
	}
}
