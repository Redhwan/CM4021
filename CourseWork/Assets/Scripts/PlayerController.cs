using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	private Vector3 originalPosR;
	private Vector3 originalPosL;
	private Vector3 moveHor;
	private Vector3 moveVer;
	private Rigidbody rightP;
	private Rigidbody leftP;
	private Vector3 jump;
	private RaycastHit what;
	private GameObject thing;
	private string under;
	private GameManager gameManager;




	void Start(){

		GameObject LevelsControllerObject = GameObject.Find ("LevelsController");
		gameManager = LevelsControllerObject.GetComponent <GameManager> ();

		moveHor = new Vector3 (2.0f, 0.0f, 0.0f);
		moveVer = new Vector3 (0.0f, 0.0f, 2.0f);
		jump = new Vector3 (0.0f, 2.0f, 0.0f);
		rightP = GameObject.Find ("RightSphere").GetComponent<Rigidbody> ();
		leftP = GameObject.Find ("LeftSphere").GetComponent<Rigidbody> ();




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


		if (Input.GetKeyDown (KeyCode.Space) & transform.position.y == 2.0f ) {

			rightP.MovePosition (orPosR + jump);
			leftP.MovePosition (orPosL + jump);
			
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


//using UnityEngine;
//using System.Collections;
//
//public class PlayerController : MonoBehaviour {
//	
//	public float speed;
//	
//	private Rigidbody rb;
//	
//	void Start ()
//	{
//		rb = GetComponent<Rigidbody>();
//	}
//	
//	void FixedUpdate ()
//	{
//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");
//		
//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//
//		rb.transform.Translate (movement * speed);
//
////		rb.AddForce (movement * speed);
//	}
//}