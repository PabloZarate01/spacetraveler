using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitv2 : MonoBehaviour
{
	private Transform theTransform;
	private Vector3 screenBounds;
	private float xLimit;
	private float yLimit;
	// Start is called before the first frame update
	void LateUpdate(){
		theTransform.position = new Vector3 (
			Mathf.Clamp(transform.position.x,-xLimit,xLimit),
			Mathf.Clamp(transform.position.y,-yLimit,yLimit),
			transform.position.z
		);
	}
	void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(
			Screen.width,Screen.height, Camera.main.transform.position.z));
		xLimit = screenBounds [0] - 0.3f;
		yLimit = screenBounds [1];
		theTransform = GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
