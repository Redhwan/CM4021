//Class to control the movement of the players.
//Code from unity API used - http://docs.unity3d.com/ScriptReference/

using UnityEngine;
using System.Collections;

public class MovePlayers : MonoBehaviour {

	private Vector3 originalPosR;
	private Vector3 originalPosL;
	private Vector3 moveHor;
	private Vector3 moveVer;
	private Rigidbody rightP;
	private Rigidbody leftP;
	private GameManager gameManager;

	
	void Start () {

		//Create reference to gameManager script
		GameObject LevelsControllerObject = GameObject.Find ("LevelsController");
		gameManager = LevelsControllerObject.GetComponent <GameManager> ();

		//Initialise variables
		moveHor = new Vector3 (2.0f, 0.0f, 0.0f);
		moveVer = new Vector3 (0.0f, 0.0f, 2.0f);
		rightP = GameObject.Find ("RightSphere").GetComponent<Rigidbody> ();
		leftP = GameObject.Find ("LeftSphere").GetComponent<Rigidbody> ();

		//This is so the ball does not rotate after bounce.
		//Code from here - http://answers.unity3d.com/questions/38542/prevent-rigidbody-from-rotating.html
		rightP.freezeRotation = true;
		leftP.freezeRotation = true;
	}

	void Update () {

		//if game is not over, get original positions of players and call movePlayers method.
		if (!gameManager.gameover) {
			originalPosR = new Vector3 (rightP.transform.position.x, rightP.transform.position.y, rightP.transform.position.z);
			originalPosL = new Vector3 (leftP.transform.position.x, leftP.transform.position.y, leftP.transform.position.z);			
			movePlayers (originalPosR, originalPosL);
		}
	}

	//Method to move spheres from original position to new position.
	void movePlayers( Vector3 orPosR, Vector3 orPosL){
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			rightP.MovePosition (orPosR + moveHor);
		} if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			rightP.MovePosition (orPosR - moveHor);
		} if (Input.GetKeyDown (KeyCode.UpArrow)) {
			rightP.MovePosition (orPosR + moveVer);
		} if (Input.GetKeyDown (KeyCode.DownArrow)) {
			rightP.MovePosition (orPosR - moveVer);
		} if (Input.GetKeyDown (KeyCode.D)) {
			leftP.MovePosition (orPosL + moveHor);
		} if (Input.GetKeyDown (KeyCode.A)) {
			leftP.MovePosition (orPosL - moveHor);
		} if (Input.GetKeyDown (KeyCode.W)) {
			leftP.MovePosition (orPosL + moveVer);
		} if (Input.GetKeyDown (KeyCode.S)) {
			leftP.MovePosition (orPosL - moveVer);
		}
	}
}
