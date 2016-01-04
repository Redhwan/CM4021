//Class to control the moving platforms.
//Got idea and code snipets from the following youtube videos.
//https://www.youtube.com/watch?v=U1UkKw12pQo
//https://www.youtube.com/watch?v=AfwmRYQRsbg
//Code from unity API used - http://docs.unity3d.com/ScriptReference/

using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public Transform a;
	public Transform b;
	public bool isLeftSide;
	public bool isHorizontal;
	private bool moveToB;
	private GameManager gameManager;
	private Transform playerParent;
	private Vector3 moveDirection;
	private Vector3 moveHor;
	private Vector3 moveVer;
	
	void Start()
	{
		//Create reference to gameManager script
		GameObject LevelsControllerObject = GameObject.Find ("LevelsController");
		gameManager = LevelsControllerObject.GetComponent <GameManager> ();

		//initialise variables. Call checkAngle method
		playerParent = GameObject.FindWithTag ("Player").transform.parent;
		moveHor = new Vector3 (2.0f, 0.0f, 0.0f);
		moveVer = new Vector3 (0.0f, 0.0f, 2.0f);
		moveToB = true;
		checkAngle ();
	}
	
	void Update()
	{

		//if game is not over, call movecheckedplatform method
		if (!gameManager.gameover){
			MoveCheckedPlatform ();
		}
	}

	//when play is on platform, make player child of the transport object. (so the player moves with the platfrom)
	void OnCollisionEnter(Collision col){
		col.transform.parent = this.gameObject.transform;
	}

	//return player parent to original when player leaves platform
	void OnCollisionExit(Collision col){
		col.transform.parent = playerParent;
	}

	//Method that checks which platform (right or left) then calls the movePlatform method
	void MoveCheckedPlatform(){
		if (isLeftSide) {
			if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.LeftArrow) || 
			    Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.RightArrow)) 
			{
				movePlatform ();
			}
		} else {
			if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.A) || 
			    Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) 
			{
				movePlatform ();
			}
		}
	}

	//Method that checks if the platfrom is moving to point a or b the moves it. 
	void movePlatform(){
		if (moveToB) {
			transform.Translate (moveDirection);
			if (transform.position == b.position) {
				moveToB = false;
			}
		} else {
			transform.Translate (-moveDirection);
			if (transform.position == a.position) {
				moveToB = true;
			}
		}
	}

	//Method to deteminr if platform is going to move horizontally or vertically
	void checkAngle(){
		if (isHorizontal) {
			moveDirection = moveHor;
		} else {
			moveDirection = moveVer;
		}
	}

}