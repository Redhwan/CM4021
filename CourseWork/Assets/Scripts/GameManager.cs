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
	
	private float checkPercRight;
	public float LvlpercentageCompleteRight;
	private float checkPercLeft;
	public float LvlpercentageCompleteLeft;

	
	
	void Start ()
	{
		checkPercRight = PlayerPrefs.GetFloat ("Lvl1Right");
		checkPercLeft = PlayerPrefs.GetFloat ("Lvl1Left");
		cam = GameObject.Find ("CameraCont");
		speed = 0.03f;
		gameover = false;
		levelcomplete = false;
	}
	
	
	void Update ()
	{
		if (gameover) {
			restart();
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
		centreText.text = (int)LvlpercentageCompleteLeft + "% | " + (int)LvlpercentageCompleteRight + "%";
		centreText.enabled = true;
		topRightText.text = "Press 'R' to retry";
		topRightText.enabled = true;
		setHighScore ();
	}

	public void restart(){
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		} if (Input.GetKeyDown (KeyCode.Q)) {
			Application.LoadLevel(0);
		} 
	}

	public void completeLevel (){
	//	PlayerPrefs.SetFloat ("Lvl1Right", 100.0f);
		setHighScore();
		levelcomplete = true;
		centreText.text = "Level Complete";
		centreText.enabled = true;
		topRightText.text = "Press any key to continue";
		topRightText.enabled = true;
	}

	void setHighScore(){
		if (Application.loadedLevel == 1) {
	if (LvlpercentageCompleteRight > checkPercRight) {
					PlayerPrefs.SetFloat ("Lvl1Right", LvlpercentageCompleteRight);
			}
	if (LvlpercentageCompleteLeft > checkPercLeft) {
					PlayerPrefs.SetFloat ("Lvl1Left", LvlpercentageCompleteLeft);
			}
		}
	}
}