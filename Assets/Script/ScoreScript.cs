using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {
	public int score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Scoreplus (float a) {
		if (a < 0.05) {
			score += 10;
		} else if (a < 0.1) {
			score += 5;
		} else {
			score += 1;
		}
	}
}
