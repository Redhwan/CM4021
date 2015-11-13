using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	private GameObject cam;
	public float speed;
	public Text gameovertext;
	public Text restarttext;
	public bool gameover;
	
	
	void Start ()
	{
		cam = GameObject.Find ("CameraCont");
		speed = 0.01f;
		gameover = false;
	}
	
	
	void Update ()
	{
		if (gameover) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel(0);
			} 
		} else {
			moveCamera(speed);
		}
	}
	
	
	void moveCamera(float s){
		cam.transform.Translate (new Vector3 (0.0f, 0.0f, s));
	}
	
	public void gameOver(){
		gameover = true;
		gameovertext.enabled = true;
		restarttext.enabled = true;
	}
}
