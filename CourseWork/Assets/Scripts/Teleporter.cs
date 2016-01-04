//Class to control teleportation of player.
//Got the idea and code snippets from Lecture on UI's
//Code from unity API used - http://docs.unity3d.com/ScriptReference/

using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	
	public GameObject destination;
	private Vector3 newPos;
	private GameManager gameManager;
	private SoundsBroadcaster sb;
	private AudioSource audioSound;
	
	void Start () {

		//Create reference to gameManager script
		GameObject LevelsControllerObject = GameObject.Find ("LevelsController");
		gameManager = LevelsControllerObject.GetComponent <GameManager> ();

		//Create reference to soundsBroadcaster script
		GameObject SoundsBroadcasterObject = GameObject.Find ("SoundsBroadcaster");
		sb = SoundsBroadcasterObject.GetComponent<SoundsBroadcaster> ();

		//getAudioSource from this object
		audioSound = GetComponent<AudioSource>();
	}

	void Update () {

		//finds and stops all particle systems if the game is over.
		if (gameManager.gameover) {
			foreach (GameObject g in GameObject.FindGameObjectsWithTag("ParticleSystem"))
			{
				g.SetActive(false);
			}
		}
	}

	//when player enters, make the position of the player the destinations position. Play and broadcast sound.
	void OnCollisionEnter(Collision col){
		newPos = new Vector3 (destination.transform.position.x, col.transform.position.y, destination.transform.position.z);
		col.transform.position = newPos;

		//next two lines came from the Lecture on BroadcastSounds
		audioSound.Play ();
		sb.broadcastSound ();
	}
}
