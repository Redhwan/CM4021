using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	private Vector3 originalPosR;
	private Vector3 originalPosL;
	private Vector3 moveHor;
	private Vector3 moveVer;
	private GameObject rightP;
	private GameObject leftP;
	private RaycastHit what;
	private GameObject thing;
	private string under;
//	private CameraCon camcon;
	private GameManager gameManager;

	void Start(){

//		GameObject CamerConObject = GameObject.Find ("BottomBoundry");
//		camcon = CamerConObject.GetComponent <CameraCon> ();

		GameObject GameManagerObject = GameObject.Find ("GameManager");
		gameManager = GameManagerObject.GetComponent <GameManager> ();

		moveHor = new Vector3 (2.0f, 0.0f, 0.0f);
		moveVer = new Vector3 (0.0f, 0.0f, 2.0f);
		rightP = GameObject.Find ("RightSphere");
		leftP = GameObject.Find ("LeftSphere");

	}

	void Update(){
//		if (camcon.gameover) {
		if (gameManager.gameover) {

		} else {

			originalPosR = new Vector3 (rightP.transform.position.x, rightP.transform.position.y, rightP.transform.position.z);
			originalPosL = new Vector3 (leftP.transform.position.x, leftP.transform.position.y, leftP.transform.position.z);

			movePlayers (originalPosR, originalPosL);
			checkBelowPlayer();

		}
	}

//	void OnCollisionEnter(Collision col) {
//
//		if (col.gameObject.name == "Platform") {
//
//			this.transform.parent = col.gameObject.transform;
//		}
//	}
//
//	void OnCollisionEnter ( Collision col){
//

//	}


	void OnTriggerEnter(Collider col){
		if (col.name == "BottomBoundry") {
//			camcon.gameOver ();
			gameManager.gameOver();
		}
	}

	 void movePlayers( Vector3 orPosR, Vector3 orPosL){

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			rightP.GetComponent<Rigidbody> ().MovePosition (orPosR + moveHor);
		} if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			rightP.GetComponent<Rigidbody> ().MovePosition (orPosR - moveHor);
		} if (Input.GetKeyDown (KeyCode.UpArrow)) {
			rightP.GetComponent<Rigidbody> ().MovePosition (orPosR + moveVer);
		} if (Input.GetKeyDown (KeyCode.DownArrow)) {
			rightP.GetComponent<Rigidbody> ().MovePosition (orPosR - moveVer);
		} if (Input.GetKeyDown (KeyCode.D)) {
			leftP.GetComponent<Rigidbody> ().MovePosition (orPosL + moveHor);
		} if (Input.GetKeyDown (KeyCode.A)) {
			leftP.GetComponent<Rigidbody> ().MovePosition (orPosL - moveHor);
		} if (Input.GetKeyDown (KeyCode.W)) {
			leftP.GetComponent<Rigidbody> ().MovePosition (orPosL + moveVer);
		} if (Input.GetKeyDown (KeyCode.S)) {
			leftP.GetComponent<Rigidbody> ().MovePosition (orPosL - moveVer);
		}
	}

	public void checkBelowPlayer(){
		
		Vector3 qwe = new Vector3 (0.0f, -1.0f, 0.0f);
		
		if (Physics.Raycast (transform.position, qwe, out what, 10)) {
			under = what.transform.gameObject.name;
			isOnLava (under);
		}
	}
	
	public void isOnLava(string lava){
		if (lava == "Terrain") {
			//			camcon.gameOver();
			gameManager.gameOver();
		}
	}

}