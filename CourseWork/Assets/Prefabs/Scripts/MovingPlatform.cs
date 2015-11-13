using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {


	public Transform a;
	public Transform b;
	public float speed;
	private float timing;
	private bool moveRight;
//	private CameraCon camcon;
	private GameManager gameManager;
	private Transform playerParent;


	void Start()
	{
//		GameObject CamerConObject = GameObject.Find ("BottomBoundry");
//		camcon = CamerConObject.GetComponent <CameraCon> ();

		GameObject GameManagerObject = GameObject.Find ("GameManager");
		gameManager = GameManagerObject.GetComponent <GameManager> ();

		playerParent = GameObject.FindWithTag ("Player").transform.parent;

		timing = 0.0f;
		speed = 0.003f;
		moveRight = true;
	}


	void Update()
	{
//		if (camcon.gameover) {
		if (gameManager.gameover){
			
		} else {

		
			movePlatform ();
		}

	}

	void OnCollisionEnter(Collision col){
		col.transform.parent = this.gameObject.transform;
	}

	void OnCollisionExit(Collision col){
		col.transform.parent = playerParent;
	}




	void movePlatform(){
		timing += speed;
		
		if (moveRight) {
			transform.position = Vector3.Lerp (a.position, b.position, timing);
			if (transform.position == b.position) {
				moveRight = false;
				timing = 0.0f;
			}
		} else {
			transform.position = Vector3.Lerp (b.position, a.position, timing);
			if (transform.position == a.position) {
				moveRight = true;
				timing = 0.0f;
			}
		}
	}


}