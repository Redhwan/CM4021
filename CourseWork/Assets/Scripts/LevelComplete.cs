//Class to control the finish line.
//Code from unity API used - http://docs.unity3d.com/ScriptReference/

using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour {

	private GameManager gameManager;

	void Start () {

		//Create reference to gameManager script
		GameObject LevelsControllerObject = GameObject.Find ("LevelsController");
		gameManager = LevelsControllerObject.GetComponent <GameManager> ();
	}

	//On collision means player has reached. Call complete level method.
	void OnCollisionEnter(Collision col){
		gameManager.completeLevel ();
	}
}
