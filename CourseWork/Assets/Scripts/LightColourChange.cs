//Class to control the colour change of the Light, to be used by soundbroadcaster.
//Idea and code snippets came from Lecture on AudioBroadcaster
//Code from unity API used - http://docs.unity3d.com/ScriptReference/

using UnityEngine;
using System.Collections;

public class LightColourChange : MonoBehaviour {

	public bool changeLight;
	private Light lt;
	private Color col;
	
	void Start () {

		//initialise variables
		lt = GetComponent<Light> ();
	}

	void Update () {

		//if changeLight is true, then change a light to random colour
		if (changeLight) {	
			col = new Color (Random.value, Random.value, Random.value, 1.0f);
			lt.color = col;
			changeLight = false;
		}
	}

	//method to "hearsound" and set changeLight to true.
	//making of this came from the Lecture on BroadcastSounds
	public void onHearSound(){
		changeLight = true;
	}
}
