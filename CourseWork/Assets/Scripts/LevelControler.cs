//Class that controls the level highscore
//Code from unity API used - http://docs.unity3d.com/ScriptReference/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelControler : MonoBehaviour {

	private float finPos;
	private float pathDistRight;
	private float pathDistLeft;
	private float strtPosRight;
	private float strtPosLeft;
	private float playerPosRight;
	private float playerPosLeft;
	private float percentageText;
	private GameManager gameManager;
	
	void Start () {

		//Create reference to gameManager script 
		GameObject LevelsControllerObject = GameObject.Find ("LevelsController");
		gameManager = LevelsControllerObject.GetComponent <GameManager> ();

		//Initialise variables and find path distance.
		strtPosRight = GameObject.Find ("RightSphere").transform.position.z;
		strtPosLeft = GameObject.Find ("LeftSphere").transform.position.z;
		finPos = GameObject.Find ("FinishLine").transform.position.z;
		pathDistRight = finPos - strtPosRight;
		pathDistLeft = finPos - strtPosLeft;
	}

	void Update () {

		//If game is not over, calculate and set the percentage of the level complete for the game.
		if (!gameManager.gameover) {
			playerPosRight = GameObject.Find ("RightSphere").transform.position.z - strtPosRight;
			playerPosLeft = GameObject.Find ("LeftSphere").transform.position.z - strtPosLeft;
			gameManager.LvlpercentageCompleteRight = (playerPosRight/pathDistRight)*100;
			gameManager.LvlpercentageCompleteLeft = (playerPosLeft/pathDistLeft)*100;
		}
	}

}
