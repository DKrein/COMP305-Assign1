/*
 * Create by Douglas Krein
 * Description: Script to take care about the game in general
 * 
 * 
*/
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject enemy;
	public GameObject enemyBoss;
	public int enemyCount;
	public Vector3 spawnValues;
	
	public GUIText scoreText;
	public GUIText lifeText;
	public GUIText restartText;
	public GUIText gameOverText;

	public int damage;

	private int score;
	private bool gameOver;
	private bool restart;
	private int waves;

	void Start() {
	
		gameOver = false;
		restart = false;

		gameOverText.text = "";
		restartText.text = "";

		score = 0;
		waves = 0;

		UpdateScore ();
		UpdateLife ();

		StartCoroutine( SpawnWaves ());
	}


	void Update() {
		if (restart) {
			if (Input.GetKeyDown("r")) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}


	IEnumerator SpawnWaves(){

		yield return new WaitForSeconds(3f);
		while(true){
			for (int i=0;i < enemyCount;i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.Euler (90.0f, 0f, 0f);
				Instantiate (enemy, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(0.7f);
			}
			waves++;
			yield return new WaitForSeconds(0.5f);

			if(gameOver){
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}

			if(waves == 2){
				yield return new WaitForSeconds(2f);
				SpawnBoss();
				waves = 0;
			}

		}	
	}


	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	public void GetHit() {
		damage = damage-25;
		UpdateLife ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	void UpdateLife() {
		lifeText.text = "Damage: " + damage;
	}

	public void GameOver(){
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	void SpawnBoss(){
		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.Euler (90.0f, 0f, 0f);
		Instantiate (enemyBoss, spawnPosition, spawnRotation);
	}
               
	                  
}
