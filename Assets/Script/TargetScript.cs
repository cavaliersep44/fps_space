using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {
	int Hp =5;
	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	public void  TargetControl (){
		Hp--;
		//print (Hp);
		if (Hp == 0) {
			anim.SetBool ("IsBroken", true);
			Invoke ("ReverseMethod", 10f);
			Hp = 5;
			}

	}
	public void ReverseMethod () {
		anim.SetBool ("IsBroken", false);
	}


}

