using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {
	[SerializeField] private GameObject fireeffect1;
	[SerializeField] private GameObject fireeffect2;
	[SerializeField] private GameObject spawn;
	[SerializeField] private int Bullet;
	[SerializeField] private int Bulletbox;
	private int reloadbullet;
	private int startBullet;
	float coolTime;
	AudioClip ReloadSound;
	AudioSource audioSource;
	//  this for initialization
	void Start () {
		ReloadSound = Resources.Load<AudioClip>("Audio/reload");//Resourcesフォルダを作成しないとロードできない。//Audioファイルも生成する。
		audioSource = transform.GetComponent<AudioSource>();
		startBullet = Bullet;
		}
	
	// Update is called once per frame
	void Update () {
		

		if (Input.GetKeyDown ("r") && Bulletbox > 0 ) {
			Reload ();
				

		}

		coolTime -= Time.deltaTime;
		if (Input.GetMouseButtonDown (0) && coolTime <=0f && Bullet !=0) { //!＝０にすることで０じゃないときうてて、０のときうてない
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			GameObject obj1 = Instantiate (fireeffect2, spawn.transform.position, Quaternion.identity);
			Destroy (obj1, 0.3f);
			coolTime = 0.3f;
			Bullet--;


			if (Physics.Raycast (ray, out hit)) { //当たってから処理をする。
					GameObject obj = Instantiate (fireeffect1, hit.point - ray.direction, Quaternion.identity) as GameObject; //位置情報もしっかりと書いておく。
					Destroy (obj, 0.3f);
				 


			

			}
		}
	}
	void Reload () {
		audioSource.PlayOneShot (ReloadSound); 
		reloadbullet = startBullet - Bullet;
		if (Bulletbox < reloadbullet) {
			Bullet += Bulletbox;
			Bulletbox = 0;


		}else{
		Bulletbox -= reloadbullet;
		Bullet += reloadbullet;



		}
	}
}
