using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelControler : MonoBehaviour {

	
	public Text LvlPercText;

	private float finPos;
	private float pathDist;
	private float strtPos;
	private float playerPos;
	private float percentageText;

	private GameManager gameManager;

	// Use this for initialization
	void Start () {

		
		GameObject LevelsControllerObject = GameObject.Find ("LevelsController");
		gameManager = LevelsControllerObject.GetComponent <GameManager> ();

		strtPos = GameObject.Find ("RightSphere").transform.position.z;
		finPos = GameObject.Find ("FinishLine").transform.position.z;
		pathDist = finPos - strtPos;

	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.gameover) {

		} else {
			playerPos = GameObject.Find ("RightSphere").transform.position.z - strtPos;
			gameManager.LvlpercentageComplete = (playerPos/pathDist)*100;
		}


	}
}
