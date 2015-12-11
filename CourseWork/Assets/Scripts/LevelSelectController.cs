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

	// Use this for initialization
	void Start () {

//		PlayerPrefs.SetFloat("Lvl1Right", 0.0f);
//		PlayerPrefs.SetFloat("Lvl1Left", 0.0f);
//		PlayerPrefs.SetFloat("tutorialRight", 0.0f);
//		PlayerPrefs.SetFloat("tutorialLeft", 0.0f);


		tutorialRight = PlayerPrefs.GetFloat ("tutorialRight");
		tutorialLeft = PlayerPrefs.GetFloat ("tutorialLeft");

		level1Right = PlayerPrefs.GetFloat ("Lvl1Right");
		level1Left = PlayerPrefs.GetFloat ("Lvl1Left");


		tutorialText.text = (int)tutorialLeft + "% | " + (int)tutorialRight + "%";
		level1Text.text = (int)level1Left + "% | " + (int)level1Right + "%";


		
		if ((int)tutorialLeft == 100 || (int)tutorialRight == 100) {
			level1Button.interactable = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


