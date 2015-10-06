/*
 * Create by Douglas Krein
 * Description: Script to controll the scroll of the background image
 * 
 * 
*/
using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = new Vector3 (0f,0f,0f);
		currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.z -= speed;

		//set the modified position to my background
		gameObject.transform.position = currentPosition;

		//check if background is going to the end, reset for the begining
		if (currentPosition.z <= -3f) {
			Reset ();
		}
	}

	//reset position of my background
	void Reset(){
		Vector3 resetPosition = new Vector3 (0f,0f,9.9f);
		gameObject.GetComponent<Transform>().position = resetPosition;
	}
}
