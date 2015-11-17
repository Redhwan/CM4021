using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	private GameObject cam;
	public float speed;
	public Text gameovertext;
	public Text restarttext;
	public bool gameover;
	
	private float checkPerc;
	public float LvlpercentageComplete;

	
	
	void Start ()
	{
		checkPerc = PlayerPrefs.GetFloat ("Lvl1");
		cam = GameObject.Find ("CameraCont");
		speed = 0.01f;
		gameover = false;



	}
	
	
	void Update ()
	{
		if (gameover) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel(1);
			} if (Input.GetKeyDown (KeyCode.Q)) {
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
		setHighScore ();
	}

	void setHighScore(){
	if (LvlpercentageComplete > checkPerc) {
		if (Application.loadedLevel == 1) {
					PlayerPrefs.SetFloat ("Lvl1", LvlpercentageComplete);
			}
//		if (Application.loadedLevel == 2) {
//				PlayerPrefs.SetFloat ("Lvl2", LvlpercentageComplete);
//			}
		}
	}
}
