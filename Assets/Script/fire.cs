using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {
	[SerializeField] private GameObject fireeffect1;
	[SerializeField] private GameObject fireeffect2;
	[SerializeField] private GameObject spawn;
	[SerializeField] private int Bullet;
	[SerializeField] private int Bulletbox;
	[SerializeField] private GameObject Target;
	[SerializeField] private  TargetScript enemy;
	[SerializeField] private GameObject Headmarker;
	[SerializeField] private GameObject obja;
	[SerializeField] private GameObject objb;
	[SerializeField] private ScoreScript ScoreManager;
	private int reloadbullet;
	private int startBullet;
	private int score;
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
		Vector3 Marker = obja.transform.position;
		
		

		if (Input.GetKeyDown ("r") && Bulletbox > 0 ) {
			Reload ();
				}

		coolTime -= Time.deltaTime;
		Target.GetComponent<TargetScript> ();
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
				enemy = hit.collider.gameObject.GetComponent<TargetScript> ();
				Vector3 hitpoint = hit.point;
				float dis = Vector3.Distance (obja.transform.position, hitpoint);

				if(enemy !=null){
					TargetScript t =Target.GetComponent<TargetScript> ();
					t.TargetControl ();
					ScoreManager.Scoreplus (dis);
				}
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
