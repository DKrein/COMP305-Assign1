/*
 * Create by Douglas Krein
 * Description: Script to move the bullet shoted by player
 * 
 * 
*/

using UnityEngine;
using System.Collections;

public class MoveShoot : MonoBehaviour {

	public float speed;
	private Rigidbody myRigidbody = new Rigidbody();

	//everytime the bullet is istanciated, it have to move
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();

		myRigidbody.velocity = transform.forward * speed;
	}

}
