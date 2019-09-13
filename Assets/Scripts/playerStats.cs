using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour
{
	public GameObject newTxt = null;
	public Text playerHighScore;
	public Text matchScore;
	int scoreInt;
	//Coins
	public Text playerTotalCoins;
	public Text matchCoins;
	int coinsInt;
    public static int prefCoinsInt;
	//SUMADOS
	int totalPlayerCoins;

    void Start()
    {
		playerHighScore.text = PlayerPrefs.GetInt ("HighScore", 0).ToString ();
		//Getting IntCoins
		prefCoinsInt = PlayerPrefs.GetInt ("TotalCoins", 0);
		//Placing coins to texfield
		playerTotalCoins.text = prefCoinsInt.ToString ();

		newTxt.SetActive (false);
    }

    // Update is called once per frame
    void Update()
	{
		if (spaceshipHealth.dead) {
            //Datos de la partida
			scoreInt = spaceshipHealth.finalScore;
			coinsInt = spaceshipHealth.finalCoins;

			matchScore.text = scoreInt.ToString ();
			matchCoins.text = coinsInt.ToString ();

            //Coins de la partida mas lo guardados anteriores
			totalPlayerCoins = coinsInt + prefCoinsInt;

			PlayerPrefs.SetInt ("TotalCoins", totalPlayerCoins);
			if (scoreInt > PlayerPrefs.GetInt ("HighScore", 0)) {
				//NewScore
				PlayerPrefs.SetInt ("HighScore", scoreInt);
				playerHighScore.text = PlayerPrefs.GetInt ("HighScore", 0).ToString ();
				newTxt.SetActive (true);
			} 
			playerTotalCoins.text = PlayerPrefs.GetInt ("TotalCoins", totalPlayerCoins).ToString ();
		}
	}
}
