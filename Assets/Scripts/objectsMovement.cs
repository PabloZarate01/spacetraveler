using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectsMovement : MonoBehaviour
{
	//public GameObject speedManager;
	private float objSpeed;
	private Vector2 screenBounds;
	private Shake shake;
	public bool animacionOff;
	public GameObject effectMeteor;

    // Update is called once per frame
	void Start(){
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(
			Screen.width,Screen.height, Camera.main.transform.position.z)); 
		shake = GameObject.FindGameObjectWithTag ("ScreenShake").GetComponent<Shake>();
	}
    void Update(){
		
		objSpeed=speedManager.objectsSpeed;
		this.transform.Translate(new Vector2(0, -objSpeed * Time.deltaTime));
		if(transform.position.y < screenBounds.y * -2){
			if(gameObject.tag == "Meteor"){
				//1pts to score
				//naveColliders.scoreCount += 1;
			}
			Destroy (this.gameObject);
		}
    }
	void OnCollisionEnter2D(Collision2D hit){
		if (hit.gameObject.tag == "Nave") {
			if (gameObject.tag == "Meteor") {
				if (!animacionOff) {
					shake.CamShake ();
					effectMeteor = Instantiate(effectMeteor);
					effectMeteor.transform.position =this.transform.position;
					Destroy (this.gameObject);
                    Destroy(effectMeteor, 1f);
                    FindObjectOfType<AudioManager>().Play("hit");
				}
			}else
			Destroy (this.gameObject);
		}
	}
}
