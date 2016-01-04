using UnityEngine;
using System.Collections;

public class PlaySounds : MonoBehaviour {

	private AudioSource audioSound;
	private GameManager gameManager;
	
	// Use this for initialization
	void Start () {
		
		GameObject LevelsControllerObject = GameObject.Find ("LevelsController");
		gameManager = LevelsControllerObject.GetComponent <GameManager> ();
		audioSound = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {


		if (!gameManager.gameover) {

			if (Input.GetKeyDown (KeyCode.RightArrow) ||
				Input.GetKeyDown (KeyCode.LeftArrow) ||
				Input.GetKeyDown (KeyCode.UpArrow) ||
				Input.GetKeyDown (KeyCode.DownArrow) ||
				Input.GetKeyDown (KeyCode.D) ||
				Input.GetKeyDown (KeyCode.A) ||
				Input.GetKeyDown (KeyCode.W) ||
				Input.GetKeyDown (KeyCode.S)) {

				audioSound.Play ();

			}

		}
	
	}


}
