//Class act as a sound broadcaster
//Idea and code snippets from Lecture on AudioBroadcaster
//Code from unity API used - http://docs.unity3d.com/ScriptReference/

using UnityEngine;
using System.Collections;

public class SoundsBroadcaster : MonoBehaviour {

	private LightColourChange lcc;

	void Start () {

		//Create reference to LightColourChange script
		GameObject LightObject = GameObject.Find ("CameraCont");
		lcc = LightObject.GetComponentInChildren<LightColourChange> ();
	
	}

	//method to "broadcast sound", calls the onHearSound method.
	public void broadcastSound(){	
		lcc.onHearSound ();
	}
}
