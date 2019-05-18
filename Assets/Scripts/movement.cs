using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
	private BoxCollider2D naveCol;
	public Sprite naveL, naveR,naveN;
	public float moveSpeed = 100f;
	public GameObject nave;
	private Rigidbody2D naveRB;
	private float screenWidth;
    // Start is called before the first frame update
    void Start()
    {
		naveCol = nave.GetComponent<BoxCollider2D> ();
		screenWidth = Screen.width;
		naveRB = nave.GetComponent<Rigidbody2D> ();
		nave.GetComponent<SpriteRenderer> ().sprite = naveN;
    }
    // Update is called once per frame
    void Update()
    {
        if (!naveCol)
        {
            return;
        }
        
		int i = 0;
		naveCol.size=new Vector2(0.5f,0.35f);;
		nave.GetComponent<SpriteRenderer> ().sprite = naveN;
		while (i < Input.touchCount) {
			if (Input.GetTouch (i).position.x > screenWidth / 2) {
                //MoveRight
                goRight();

            }
			if (Input.GetTouch (i).position.x < screenWidth / 2) {
                //Left
                goLeft();

            }
			i++;
		}
        
    }
    public void goLeft()
    {
        naveCol.size = new Vector2(0.3f, 0.35f); ;
        nave.GetComponent<SpriteRenderer>().sprite = naveL;
        MoveNave(-1.0f);
    }
    public void goRight()
    {
        naveCol.size = new Vector2(0.3f, 0.35f); ;
        nave.GetComponent<SpriteRenderer>().sprite = naveR;
        MoveNave(1.0f);
    }
    void FixedUpdate(){
		#if UNITY_EDITOR
		MoveNave(Input.GetAxis("Horizontal"));
		#endif
	}
	public void MoveNave(float horizontalInput){
        if (naveCol)
        {
            naveRB.transform.Translate
                (new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));
        }
	}
}
