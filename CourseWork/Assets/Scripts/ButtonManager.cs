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


}
