﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
	[Header ("Loading")]
	public GameObject loadingScreen;
	public Slider slider;
    [Header("Menu")]
	public GameObject menuScreen;
	public GameObject settingsScreen;
	[Header ("Settings")]
	public GameObject wrngScreen;
	public GameObject wrngWindow;
	public GameObject prefsAlert;
    private void Start()
    {
        
        Debug.Log("Found!");
        string nameScene = SceneManager.GetActiveScene().name;
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("MyScene" + nameScene + "intt" + indexScene);
        if (indexScene == 1)
        {
            AdStart.instance.HideBannerAd();
                
        }
        else if (indexScene == 0)
        {
            AdStart.instance.DisplayBannerAd();
        }
    }
    public void LoadLevel(int sceneIndex){
        FindObjectOfType<AudioManager>().Play("uiclick");
        float x = Random.Range(0,10);
        Debug.Log(x);
        if(x > 4)
        {
            Debug.Log("AddAppear");
            AdStart.instance.DisplayInterstitialAd();
            StartCoroutine(LoadAsynchronysly(sceneIndex));
        }else
        {
            StartCoroutine(LoadAsynchronysly(sceneIndex));
            Debug.Log("NoAd");
        }
    }
	IEnumerator LoadAsynchronysly(int sceneIndex){
		AsyncOperation operation =SceneManager.LoadSceneAsync (sceneIndex);
		loadingScreen.SetActive (true);
		while(!operation.isDone){
			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
			slider.value = progress;
			yield return null;
		}
	}
	public void exit()
    {
        FindObjectOfType<AudioManager>().Play("uiclick");
        Application.Quit ();
	}
	public void settings(){
        FindObjectOfType<AudioManager>().Play("uiclick");
        menuScreen.SetActive (false);
		settingsScreen.SetActive (true);
	}
	public void settingsBackMenu(){
        FindObjectOfType<AudioManager>().Play("uiclick");
        settingsScreen.SetActive (false);
		menuScreen.SetActive (true);
	}
	public void clearPlayerPrefs(){
        FindObjectOfType<AudioManager>().Play("uiclick");
        PlayerPrefs.DeleteAll ();
		wrngWindow.SetActive (false);
		prefsAlert.SetActive (true);
	}
	public void warningPlayerStats(){
        FindObjectOfType<AudioManager>().Play("uiclick");
        wrngScreen.SetActive (true);
		wrngWindow.SetActive (true);
		prefsAlert.SetActive (false);
	}
	public void warningClose(){
        FindObjectOfType<AudioManager>().Play("uiclick");
        wrngScreen.SetActive (false);
	}
}
