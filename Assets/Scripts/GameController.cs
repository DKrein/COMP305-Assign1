using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject enemy;
	public int enemyCount;
	public Vector3 spawnValues;
	
	public GUIText scoreText;
	public GUIText lifeText;
	public GUIText restartText;
	public GUIText gameOverText;

	private int score;
	private int lives;
	private bool gameOver;
	private bool restart;

	void Start() {
	
		gameOver = false;
		restart = false;

		//gameOverText.text = "";
		//restartText.text = "";

		score = 0;
		lives = 3;

		UpdateScore ();
		UpdateLife ();

		StartCoroutine( SpawnWaves ());
	}

	/*
	void Update() {
		if (restart) {
			if (Input.GetKeyDown("r")) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	*/

	IEnumerator SpawnWaves(){

		yield return new WaitForSeconds(3f);
		while(true){
			for (int i=0;i < enemyCount;i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (90.0f, 0f, 0f);
				Instantiate (enemy, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(0.7f);
			}
			yield return new WaitForSeconds(1f);

			/*if(gameOver){
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
			*/
		}	
	}


	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	void UpdateLife() {
		lifeText.text = "Lives: " + lives;
	}
	/*
	public void GameOver(){
		gameOverText.text = "Game Over";
		gameOver = true;
	}
	  */                 
	                  
}
