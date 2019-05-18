using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class spaceshipHealth : MonoBehaviour
{
	//HPBAR_DMG
	public GameObject nave;
	[Header("Healht & Damage")]
	public Slider healthBar;
	public float currentHealth;
	private float maxHealth = 100f;
	public static bool dead;
	public GameObject deadPanel, effectDestroy;
	//DeadPanel
	public Text matchScore;
	public Text matchCoins;
	public Text playerHScore;
	public Text playerTotalCoins;
	//V
	public static int finalScore = naveColliders.scoreCount;
	public static int finalCoins = naveColliders.coinsCount;
    void Start()
    {
		nave.SetActive(true);
		maxHealth = 100f;
		dead = false;
		currentHealth = maxHealth;
		healthBar.value = calculateHealth ();
    }

	public void TakeDamage(float dmgValue){
		currentHealth -= dmgValue;
		healthBar.value = calculateHealth ();
		if(currentHealth <= 0){
			Rip ();
		}
	}
	public void Rip(){
		currentHealth = 0;
		dead = true;
		deadPanel.SetActive (true);
		finalScore = naveColliders.scoreCount;
		finalCoins = naveColliders.coinsCount;
		matchScore.text = finalScore.ToString ();
		matchCoins.text = finalCoins.ToString ();
		nave.SetActive(false);
		effectDestroy = Instantiate(effectDestroy);
		effectDestroy.transform.position =this.transform.position;
		Destroy (this.gameObject);
		//Time.timeScale = 0f;
	}
	public float calculateHealth(){
		return currentHealth / maxHealth;
	}
	void OnCollisionEnter2D(Collision2D hit){
		if (hit.gameObject.tag == "Meteor") {
			TakeDamage (34f);
		}
	}
}
