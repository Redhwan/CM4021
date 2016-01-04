//Class to control the LevelSelect highscore text and button availability.
//Code from unity API used - http://docs.unity3d.com/ScriptReference/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour {
	
	private float level1Right;
	private float level1Left;
	private float tutorialRight;
	private float tutorialLeft;
	public Button level1Button;
	public Text level1Text;
	public Text tutorialText;
	public bool lvl1Complete;

	void Start () {
 
		//Get playerprefs (highscores)
		tutorialRight = PlayerPrefs.GetFloat ("tutorialRight");
		tutorialLeft = PlayerPrefs.GetFloat ("tutorialLeft");
		level1Right = PlayerPrefs.GetFloat ("Lvl1Right");
		level1Left = PlayerPrefs.GetFloat ("Lvl1Left");

		//Set text to highscore
		tutorialText.text = (int)tutorialLeft + "% | " + (int)tutorialRight + "%";
		level1Text.text = (int)level1Left + "% | " + (int)level1Right + "%";

		//Check if level1 has been unlocked to enable/disable the button.
		if ((int)tutorialLeft == 100 || (int)tutorialRight == 100) {
			level1Button.interactable = true;
		}
	}
}


