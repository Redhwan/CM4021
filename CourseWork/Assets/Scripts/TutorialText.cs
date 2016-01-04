//Class to show tutorial text in tutorial level.
//Code from unity API used - http://docs.unity3d.com/ScriptReference/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour {

	private Transform rightP;
	private Transform leftP;
	public Text TutText;
	
	void Start () {

		//get players transform
		rightP = GameObject.Find ("RightSphere").GetComponent<Transform>();
		leftP = GameObject.Find ("LeftSphere").GetComponent<Transform>();
	}

	void Update () {

		//Use player z position to show tutorial text.
		if (rightP.position.z < 34 && leftP.position.z < 34) {
			TutText.text = "Arrow keys control the right sphere." + System.Environment.NewLine + "W,A,S,D control the left sphere." + System.Environment.NewLine + "Try to reach the finish line with out falling off the path." ;
		} else if (rightP.position.z > 32 && rightP.position.z < 54 || leftP.position.z > 32 && leftP.position.z < 54) {
			TutText.text = "There are areas which will bounce the balls in order to reach higher steps.";
		} else if (rightP.position.z > 54 && rightP.position.z < 80 || leftP.position.z > 54 && leftP.position.z < 80) {
			TutText.text = "Teleporters will teleport you from an area to another when you move onto it";
		} else if (rightP.position.z > 78 && rightP.position.z < 110 || leftP.position.z > 78 && leftP.position.z < 110) {
			TutText.text = "Platforms move back and forth from two points." + System.Environment.NewLine + "Moving the right sphere will move the left platform." + System.Environment.NewLine + "Moving the left sphere will move the right platform.";
		} else {
			TutText.text = "Great. Good luck on the rest of the game.";
		}
	}
}
