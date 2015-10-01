using UnityEngine;
using System.Collections;

public class MoveShoot : MonoBehaviour {

	public float speed;
	private Rigidbody myRigidbody = new Rigidbody();

	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();

		myRigidbody.velocity = transform.forward * speed;
	}

}
