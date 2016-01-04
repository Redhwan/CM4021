//Method to check if player is still alive
//Ray cast idea and code snippets came from Lecture on AudioBroadcaster
//Code from unity API used - http://docs.unity3d.com/ScriptReference/

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private RaycastHit what;
	private GameObject thing;
	private string under;
	private GameManager gameManager;

	void Start(){

		//Create reference to gameManager script
		GameObject LevelsControllerObject = GameObject.Find ("LevelsController");
		gameManager = LevelsControllerObject.GetComponent <GameManager> ();
	}

	void Update(){

		//If game is not over call checkBelowPlayer method
		if (!gameManager.gameover) {
			checkBelowPlayer();
		}
	}

	//if camera boundy reaches, call gameOver method
	void OnTriggerEnter(Collider col){
		if (col.name == "BottomBoundry") {
			gameManager.gameOver();
		}
	}

	//Check below the player, if its lava call gameover method.
	public void checkBelowPlayer(){
		if (Physics.Raycast (transform.position, Vector3.down, out what, 10)) {
			under = what.transform.gameObject.name;
			if(under == "Terrain") {
				gameManager.gameOver();
			}
		}
	}
}