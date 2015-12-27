using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	private Button level1Button;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickTutorial(){
		Application.LoadLevel (1);
	}

	public void onClickL1(){
		Application.LoadLevel (2);
	}

	public void onClickReset(){

		PlayerPrefs.SetFloat ("Lvl1Right", 0.0f);
		PlayerPrefs.SetFloat ("Lvl1Left", 0.0f);
		PlayerPrefs.SetFloat ("tutorialRight", 0.0f);
		PlayerPrefs.SetFloat ("tutorialLeft", 0.0f);
		Application.LoadLevel(Application.loadedLevel);
	}
	


}
