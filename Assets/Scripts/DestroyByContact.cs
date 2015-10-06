/*
 * Create by Douglas Krein
 * Description: Script to destroy enemies when colide with other object
 * 
 * 
*/
using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;

	void Start() {
		//Find the game Controller and set to a variable
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		//Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			//Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GetHit();

			//If player have damage 0 it destroy player and finish the game 
			if (gameController.damage <=0){
				Destroy(other.gameObject);
				//Call the gameover function
				gameController.GameOver();
			}
		}

		gameController.AddScore (scoreValue);

		//destroy enemy
		Destroy(gameObject);

		//destroy bullet
		if (other.tag != "Player") {
			Destroy (other.gameObject);
		}
	} 
}
