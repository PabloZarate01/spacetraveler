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
	public GameObject revivePanel, deadPanel, effectDestroy;
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
            FindObjectOfType<AudioManager>().Play("death");
            effectDestroy = Instantiate(effectDestroy);
            effectDestroy.transform.position = this.transform.position;
            revivePanel.SetActive(true);
            currentHealth = 0;
            dead = true;
            nave.SetActive(false);
        }
	}
    public void watchReward()
    {
        AdStart.instance.DisplayRewardAd();
        AdStart.instance.RequestVideoAd();
        JesusRevive();
    }
	public void Rip()
    {
        revivePanel.SetActive(false);
        deadPanel.SetActive (true);
		finalScore = naveColliders.scoreCount;
		finalCoins = naveColliders.coinsCount;
		matchScore.text = finalScore.ToString ();
		matchCoins.text = finalCoins.ToString ();
        nave.SetActive(false);
        //Time.timeScale = 0f;
    }
    public void JesusRevive()
    {
        nave.SetActive(true);
        nave.GetComponent<naveColliders>().runScoreCount(naveColliders.scoreCount, naveColliders.coinsCount);
        currentHealth = maxHealth;
        healthBar.value = calculateHealth();
        revivePanel.SetActive(false);
        FindObjectOfType<AudioManager>().Play("death");
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
