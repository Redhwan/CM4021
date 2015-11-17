using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	private GameObject cam;
	public float speed;
	public Text centreText;
	public Text topRightText;
	public bool gameover;
	public bool levelcomplete;
	
	private float checkPerc;
	public float LvlpercentageComplete;

	
	
	void Start ()
	{
		checkPerc = PlayerPrefs.GetFloat ("Lvl1");
		cam = GameObject.Find ("CameraCont");
		speed = 0.03f;
		gameover = false;
		levelcomplete = false;
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
			if(levelcomplete){
				completeLevel();
				if (Input.anyKeyDown) {
					Application.LoadLevel(2);
				}


			} else {
			moveCamera(speed);
			}
		}
	}
	
	
	void moveCamera(float s){
		cam.transform.Translate (new Vector3 (0.0f, 0.0f, s));
	}
	
	public void gameOver(){
		gameover = true;
		centreText.text = (int)LvlpercentageComplete + "%";
		centreText.enabled = true;
		topRightText.text = "Press 'R' to retry";
		topRightText.enabled = true;
		setHighScore ();
	}

	public void completeLevel (){
		PlayerPrefs.SetFloat ("Lvl1", 100.0f);
		levelcomplete = true;
		centreText.text = "Level Complete";
		centreText.enabled = true;
		topRightText.text = "Press any key to continue";
		topRightText.enabled = true;
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
