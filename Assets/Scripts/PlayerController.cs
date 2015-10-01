using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	public Boundary boundary;

	private Rigidbody myRigidbody = new Rigidbody();
	private float nextFire;

	void Start() {
		myRigidbody = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate () {
	
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movment = new Vector3 (moveHorizontal,0.0f,moveVertical);
		myRigidbody.velocity = movment * speed;


		myRigidbody.position = new Vector3 
		(
				Mathf.Clamp(myRigidbody.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp(myRigidbody.position.z, boundary.zMin, boundary.zMax)
		);

		myRigidbody.rotation = Quaternion.Euler (90.0f, 0.0f, myRigidbody.velocity.x * -tilt);

	}
}
