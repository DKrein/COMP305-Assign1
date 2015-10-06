using UnityEngine;
using System.Collections;

public class MoveEnemyBoss : MonoBehaviour {

	public float speed;
	private Rigidbody myRigidbody = new Rigidbody();
	
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
		//it is -1 because I want the enemy go south
		Vector3 movment = new Vector3 (0.0f,0.0f,1f * speed * -1);
		myRigidbody.velocity = movment;
		
	}
}
