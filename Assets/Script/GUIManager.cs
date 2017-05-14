using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	[SerializeField] private fire fire;
	[SerializeField] private ScoreScript ScoreScript;
	[SerializeField] private Text time;
	[SerializeField] private Text Pt;
	[SerializeField] private Text Bullet;
	[SerializeField] private Text BulletBox;
	public float timer;
	// Use this for initialization
	void Start () {
		timer = 70;
		
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		Bullet.text = "Bullet :" + fire.Bullet;
		BulletBox.text = "BulletBox :" + fire.Bulletbox;
		time.text = "time :" + timer;
		Pt.text = "Pt :" + ScoreScript.score;
	}
}
