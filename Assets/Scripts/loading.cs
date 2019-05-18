using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
	[Header ("Loading")]
	public GameObject loadingScreen;
	public Slider slider;
	[Header ("Menu")]
	public GameObject menuScreen;
	public GameObject settingsScreen;
	[Header ("Settings")]
	public GameObject wrngScreen;
	public GameObject wrngWindow;
	public GameObject prefsAlert;
		
	public void LoadLevel(int sceneIndex){
		StartCoroutine (LoadAsynchronysly(sceneIndex));

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
	public void exit(){
		Application.Quit ();
	}
	public void settings(){
		menuScreen.SetActive (false);
		settingsScreen.SetActive (true);
	}
	public void settingsBackMenu(){
		settingsScreen.SetActive (false);
		menuScreen.SetActive (true);
	}
	public void clearPlayerPrefs(){
		PlayerPrefs.DeleteAll ();
		wrngWindow.SetActive (false);
		prefsAlert.SetActive (true);
	}
	public void warningPlayerStats(){
		wrngScreen.SetActive (true);
		wrngWindow.SetActive (true);
		prefsAlert.SetActive (false);
	}
	public void warningClose(){
		wrngScreen.SetActive (false);
	}
}
