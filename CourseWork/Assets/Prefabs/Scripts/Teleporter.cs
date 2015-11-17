using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

//	private GameObject player;
	public GameObject destination;
	private Vector3 newPos;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {

		GameObject LevelsControllerObject = GameObject.Find ("LevelsController");
		gameManager = LevelsControllerObject.GetComponent <GameManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (gameManager.gameover) {
			foreach (GameObject g in GameObject.FindGameObjectsWithTag("ParticleSystem"))
			{
				g.SetActive(false);
			}
		} else { 

		}
	


	}

	void OnCollisionEnter(Collision col){
		newPos = new Vector3 (destination.transform.position.x, col.transform.position.y, destination.transform.position.z);
		col.transform.position = newPos;
	}
}
