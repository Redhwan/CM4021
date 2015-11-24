using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour {


	private float level1Right;
	private float level1Left;

	public Button level2Button;

	public Text level1Text;
	public Text level2Text;

	public bool lvl1Complete;

	// Use this for initialization
	void Start () {

//		PlayerPrefs.SetFloat("Lvl1Right", 0.0f);
//		PlayerPrefs.SetFloat("Lvl1Left", 0.0f);


		level1Right = PlayerPrefs.GetFloat ("Lvl1Right");
		level1Left = PlayerPrefs.GetFloat ("Lvl1Left");


		level1Text.text = (int)level1Left + "% | " + (int)level1Right + "%";

		
		if ((int)level1Left == 100 || (int)level1Right == 100) {
			level2Button.interactable = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
