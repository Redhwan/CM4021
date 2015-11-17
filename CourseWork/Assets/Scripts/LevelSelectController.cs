using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour {


	private float level1;
	private float level2;

	public Button level2Button;

	public Text level1Text;
	public Text level2Text;

	public bool lvl1Complete;

	// Use this for initialization
	void Start () {

		level1 = PlayerPrefs.GetFloat ("Lvl1");
		level2 = PlayerPrefs.GetFloat ("Lvl2");

		level1Text.text = (int)level1+ "%";
		level2Text.text = (int)level2 + "%";

		
		if ((int)level1 == 100) {
			level2Button.interactable = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
