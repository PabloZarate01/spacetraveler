using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parallax : MonoBehaviour
{
	public float parallaxSpeed = 0.08f;
	public RawImage background,background1,background2;
	float finalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect(0f, background.uvRect.y + finalSpeed/4,1f,1f);
		background1.uvRect = new Rect(0f, background1.uvRect.y + finalSpeed/2,1f,1f);
		background2.uvRect = new Rect(0f, background1.uvRect.y + finalSpeed,1f,1f);
	}

}
