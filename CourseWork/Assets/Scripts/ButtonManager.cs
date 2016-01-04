// Class to control the buttons in the levelselct scene.


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	//Method to load Tutorial Level
	public void onClickTutorial(){
		Application.LoadLevel (1);
	}

	//Method to load Level 1
	public void onClickL1(){
		Application.LoadLevel (2);
	}

	//Method to reset all scores and reload the scene.
	public void onClickReset(){
		PlayerPrefs.SetFloat ("Lvl1Right", 0.0f);
		PlayerPrefs.SetFloat ("Lvl1Left", 0.0f);
		PlayerPrefs.SetFloat ("tutorialRight", 0.0f);
		PlayerPrefs.SetFloat ("tutorialLeft", 0.0f);
		Application.LoadLevel(Application.loadedLevel);
	}

}
