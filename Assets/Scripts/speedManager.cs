using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedManager : MonoBehaviour
{
	[Header("Parallax")]
	public float parallaxSpeed = 0.0f;
	public RawImage background0,background1,background2;
	[Header("Speed")]
	public float generalSpeed = 0.0f;
	public static float objectsSpeed = 0.0f;
	private float scoreC = 0.0f;
	public static float scoreSpeedPlus = 0.0f;
	public static float maxSpeed = 11.0f;
	// Start is called before the first frame update
	void Start(){
		generalSpeed = 1.0f;
		Time.timeScale = 1f;
	}

	// Update is called once per frame
	void Update(){
		scoreC = naveColliders.scoreCount + 1;
		scoreSpeedPlus = scoreC/50;
		if(objectsSpeed < maxSpeed){
			objectsSpeed = generalSpeed + scoreSpeedPlus;
		}
		//parallax
		parallaxSpeed = objectsSpeed / 15f;
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background2.uvRect = new Rect(0f, background2.uvRect.y + finalSpeed,1f,1f);
		background1.uvRect = new Rect(0f, background1.uvRect.y + finalSpeed/2,1f,1f);
		background0.uvRect = new Rect(0f, background0.uvRect.y + finalSpeed/4,1f,1f);
	}
}
