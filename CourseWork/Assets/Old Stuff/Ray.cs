using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Ray : MonoBehaviour {

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


	}

	// Update is called once per frame
	void Update () {
//		if (camcon.gameover) {	

		if (gameManager.gameover) {
		} else {
			checkBelowPlayer();
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
