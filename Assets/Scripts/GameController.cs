using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValue;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start(){
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";

		StartCoroutine(SpawnWave ());
		score = 0;
		UpdateScore ();
	}

	void Update(){
		if (restart) {
			if(Input.GetKeyDown(KeyCode.R)){
				SceneManager.LoadScene("Main");
			}
		}
	}

	void UpdateScore(){
		scoreText.text = "Score:" + score.ToString();
	}
	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	IEnumerator SpawnWave(){
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	public void GameOver(){
		gameOverText.text = "Game Over";
		gameOver = true;
	}
}
