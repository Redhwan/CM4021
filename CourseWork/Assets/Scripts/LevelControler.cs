using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelControler : MonoBehaviour {

	
//	public Text LvlPercText;

	private float finPos;
	private float pathDistRight;
	private float pathDistLeft;
	private float strtPosRight;
	private float strtPosLeft;
	private float playerPosRight;
	private float playerPosLeft;
	private float percentageText;

	private GameManager gameManager;

	// Use this for initialization
	void Start () {

		
		GameObject LevelsControllerObject = GameObject.Find ("LevelsController");
		gameManager = LevelsControllerObject.GetComponent <GameManager> ();

		strtPosRight = GameObject.Find ("RightSphere").transform.position.z;
		strtPosLeft = GameObject.Find ("LeftSphere").transform.position.z;
		finPos = GameObject.Find ("FinishLine").transform.position.z;
		pathDistRight = finPos - strtPosRight;
		pathDistLeft = finPos - strtPosLeft;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.gameover) {

		} else {
			playerPosRight = GameObject.Find ("RightSphere").transform.position.z - strtPosRight;
			playerPosLeft = GameObject.Find ("LeftSphere").transform.position.z - strtPosLeft;
			gameManager.LvlpercentageCompleteRight = (playerPosRight/pathDistRight)*100;
			gameManager.LvlpercentageCompleteLeft = (playerPosLeft/pathDistLeft)*100;
		}


	}
}
