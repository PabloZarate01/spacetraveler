using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
	public Animator camAnim;
	public Animator bgAnim;

	public void CamShake(){
		camAnim.SetTrigger("shake");
		bgAnim.SetTrigger("shakebg");
	}

}
