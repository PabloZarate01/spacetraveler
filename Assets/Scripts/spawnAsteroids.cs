using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAsteroids : MonoBehaviour
{
	[Header("Game Objects")]
	public GameObject[] asteroid;
	public GameObject[] monedas;
	[Header("Times")]
	public float respawnMeteorTime = 1.0f;
	public float respawnCoinTime = 6f;
	private Vector2 screenBounds;
	[Header("Spawn Objects")]
	public static bool stop = false;
	[Header("Speed")]
	private float scoreSpeed;
	private int scoreCnt;
    // Start is called before the first frame update
    void Start()
    {
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(
			Screen.width,Screen.height, Camera.main.transform.position.z));
		screenBounds.x -= 0.3f;
		StartCoroutine (objectWave ());
		StartCoroutine (coinWave());
	}

    // Update is called once per frame
    void Update()
    {
		scoreSpeed = speedManager.scoreSpeedPlus;
		scoreCnt = naveColliders.scoreCount;
		spawnLvl ();
    }
	private void spawnObject(){
		GameObject a = Instantiate (asteroid[Random.Range(0, 3)]) as GameObject;
		a.transform.position = new Vector2 (Random.Range(-screenBounds.x, screenBounds.x)
			, screenBounds.y * 2);
	}
	private void spawnCoin(){
		
		GameObject coin = Instantiate (monedas[Random.Range(0,2)]) as GameObject;
		coin.transform.position = new Vector2 (Random.Range(-screenBounds.x, screenBounds.x)
			, screenBounds.y * 2);
	}

	IEnumerator objectWave(){
		while(!stop){
			yield return new WaitForSeconds (respawnMeteorTime);
			spawnObject ();
		}

	}
	IEnumerator coinWave(){
		while(!stop){
			yield return new WaitForSeconds (respawnCoinTime);
			spawnCoin ();
		}
	}
	void spawnLvl(){
		if(scoreCnt == 10){
			respawnMeteorTime = 0.7f;
			respawnCoinTime = 5f;
		}
		if(scoreCnt == 50){
			respawnMeteorTime = 0.6f;
			respawnCoinTime = 4f;
		}
		if(scoreCnt == 100){
			respawnMeteorTime = 0.5f;
			respawnCoinTime = 3f;
		}
		if(scoreCnt == 200){
			respawnMeteorTime = 0.4f;

			respawnCoinTime = 2.5f;
		}
		if(scoreCnt == 250){
			respawnMeteorTime = 0.3f;
			respawnCoinTime = 2.0f;
		}
		if(scoreCnt == 300){
			respawnMeteorTime = 0.2f;
			respawnCoinTime = 1.5f;
		}
		if(scoreCnt == 350){
			respawnMeteorTime = 0.15f;
			respawnCoinTime = 1.0f;
		}
	}
}
