using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {


	public Transform a;
	public Transform b;
	public bool isLeftSide;
	public bool isHorizontal;
	private bool moveRight;
	private GameManager gameManager;
	private Transform playerParent;
	private Vector3 moveDirection;
	private Vector3 moveHor;
	private Vector3 moveVer;


	void Start()
	{
		GameObject GameManagerObject = GameObject.Find ("GameManager");
		gameManager = GameManagerObject.GetComponent <GameManager> ();
		playerParent = GameObject.FindWithTag ("Player").transform.parent;

		moveHor = new Vector3 (2.0f, 0.0f, 0.0f);
		moveVer = new Vector3 (0.0f, 0.0f, 2.0f);

		checkAngle ();
		moveRight = true;

	}


	void Update()
	{


		if (gameManager.gameover){
			
		} else {
		
			MoveCheckedPlatform ();
		
		}

	}

	void OnCollisionEnter(Collision col){
		col.transform.parent = this.gameObject.transform;
	}

	void OnCollisionExit(Collision col){
		col.transform.parent = playerParent;
	}



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


	void movePlatform(){
		if (moveRight) {
			transform.Translate (moveDirection);
			if (transform.position == b.position) {
				moveRight = false;
			}
		} else {
			transform.Translate (-moveDirection);
			if (transform.position == a.position) {
				moveRight = true;
			}
		}
	}

	void checkAngle(){
		if (isHorizontal) {
			moveDirection = moveHor;
		} else {
			moveDirection = moveVer;
		}
	}


//	void movePlatform(){
//		timing += speed;
//		
//		if (moveRight) {
//			transform.position = Vector3.Lerp (a.position, b.position, timing);
//			if (transform.position == b.position) {
//				moveRight = false;
//				timing = 0.0f;
//			}
//		} else {
//			transform.position = Vector3.Lerp (b.position, a.position, timing);
//			if (transform.position == a.position) {
//				moveRight = true;
//				timing = 0.0f;
//			}
//		}
//	}


}