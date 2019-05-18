using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parallax1 : MonoBehaviour
{
	public float parallaxSpeed = 0.05f;
	public RawImage background,front;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect(0f, background.uvRect.y + finalSpeed/2,1f,1f);
		front.uvRect = new Rect(0f, front.uvRect.y + finalSpeed,1f,1f);
    }
}
