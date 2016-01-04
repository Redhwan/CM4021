//Class that controls the main game mechanics

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
	
	void Start () {

		//Check which level is load to set the variable with the right preferences for high scores.
		if (Application.loadedLevel == 1) {
			checkPercRight = PlayerPrefs.GetFloat ("tutorialRight");
			checkPercLeft = PlayerPrefs.GetFloat ("tutorialLeft");
		}else if (Application.loadedLevel == 2) {
			checkPercRight = PlayerPrefs.GetFloat ("Lvl1Right");
			checkPercLeft = PlayerPrefs.GetFloat ("Lvl1Left");
		}

		//Initialise variables. Set speed.
		cam = GameObject.Find ("CameraCont");
		speed = 0.03f;
		gameover = false;
		levelcomplete = false;

	}

	void Update ()
	{
		//If game is not over, move the camera. If game is over, call restart, if the level is complete, call complete level allow the user to load to next level.
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
	
	//Method to move the camera forward at 's' speed
	void moveCamera(float s){
		cam.transform.Translate (new Vector3 (0.0f, 0.0f, s));
	}

	//Method for gameover, show high score, allow user to restart and call setHighScore method.
	public void gameOver(){
		gameover = true;
		centreText.text = (int)LvlpercentageCompleteLeft + "% | " + (int)LvlpercentageCompleteRight + "%";
		centreText.enabled = true;
		topRightText.text = "Press 'R' to retry\nPress 'Q' to quit";
		topRightText.enabled = true;
		setHighScore ();
	}

	//Method to let user restart/quit.
	public void restart(){
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		} if (Input.GetKeyDown (KeyCode.Q)) {
			Application.LoadLevel(0);
		} 
	}

	//Method to complete level, calls setHighscore method, shows relevant text and score.
	public void completeLevel (){
		setHighScore();
		levelcomplete = true;
		centreText.text = "Level Complete";
		centreText.enabled = true;
		topRightText.text = "Press any key to continue" ;
		topRightText.enabled = true;
	}

	//Method to set highscore, checks which level, then checks if user has beat previous highscore.
	void setHighScore(){
		if (Application.loadedLevel == 1) {
			if (LvlpercentageCompleteRight > checkPercRight) {
				PlayerPrefs.SetFloat ("tutorialRight", LvlpercentageCompleteRight);
			}
			if (LvlpercentageCompleteLeft > checkPercLeft) {
				PlayerPrefs.SetFloat ("tutorialLeft", LvlpercentageCompleteLeft);
			}
		}else if (Application.loadedLevel == 2) {
			if (LvlpercentageCompleteRight > checkPercRight) {
					PlayerPrefs.SetFloat ("Lvl1Right", LvlpercentageCompleteRight);
			}
			if (LvlpercentageCompleteLeft > checkPercLeft) {
					PlayerPrefs.SetFloat ("Lvl1Left", LvlpercentageCompleteLeft);
			}
		}
	}
}