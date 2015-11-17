using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {


	private float level1;
	private float level2;

	public Text level1Text;
	public Text level2Text;

	// Use this for initialization
	void Start () {

		level1 = PlayerPrefs.GetFloat ("Lvl1");
		level2 = PlayerPrefs.GetFloat ("Lvl2");
	
		level1Text.text = level1 + "%";
		level2Text.text = level2 + "%";

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
