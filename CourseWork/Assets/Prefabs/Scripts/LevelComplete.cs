using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour {

	private GameManager gameManager;

	// Use this for initialization
	void Start () {

		
		GameObject LevelsControllerObject = GameObject.Find ("LevelsController");
		gameManager = LevelsControllerObject.GetComponent <GameManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter(Collision col){
		gameManager.completeLevel ();
	}

}
