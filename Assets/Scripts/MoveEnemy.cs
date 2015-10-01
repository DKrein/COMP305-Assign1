using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour {

	public float speed;
	private Rigidbody myRigidbody = new Rigidbody();
	
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();

		Vector3 movment = new Vector3 (0.0f,0.0f,1f * speed * -1);

		myRigidbody.velocity = movment;

	}
}
