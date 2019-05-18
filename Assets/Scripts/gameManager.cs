using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
	public GameObject pausePanel;
	private bool deadC = spaceshipHealth.dead;
    // Start is called before the first frame update
	public void pause(){
		pausePanel.SetActive (true);
		Time.timeScale = 0f;
	}
	public void resume(){
		pausePanel.SetActive (false);
		Time.timeScale = 1f;
	}
}
