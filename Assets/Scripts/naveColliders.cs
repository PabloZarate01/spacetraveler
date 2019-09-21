using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class naveColliders : MonoBehaviour
{
	
	//COINS_SCORE
	[Header("Coins Values")]
	public Text coinsText;
	public Text scoreText;
	public int[] coinsValues;
	public static int coinsCount = 0;
	public static int scoreCount = 0;
	//COINS_SCORE
	void Start(){
		coinsCount = 0;
		scoreCount = 0;
		coinsText.GetComponent<Text> ();
		scoreText.GetComponent<Text> ();
		StartCoroutine (ScoreCounterIE());
	}

	void Update(){
		coinsText.text = coinsCount.ToString ();
		scoreText.text = scoreCount.ToString ();
	}
	IEnumerator ScoreCounterIE(){
		while (true) {
			yield return new WaitForSeconds(0.2f);
			scoreCount += 1;
		}
	}

	//Add amount of coins
	void addCoin1(){
		coinsCount += coinsValues [0];
	}
	void addCoin2(){
		coinsCount += coinsValues [1];
	}
	void addCoin3(){
		coinsCount += coinsValues [2];
	}
	void OnCollisionEnter2D(Collision2D hit){
        if (hit.gameObject.tag == "Coin1")
        {
            addCoin1();
            FindObjectOfType<AudioManager>().Play("coin");
        }
			
		if(hit.gameObject.tag=="Coin2")
        {
            addCoin2();
            FindObjectOfType<AudioManager>().Play("coin");
        }
        if (hit.gameObject.tag=="Coin3")
        {
            addCoin3();
            FindObjectOfType<AudioManager>().Play("coin");
        }
    }
	//ENDCOINS

}//ENDCLASS
