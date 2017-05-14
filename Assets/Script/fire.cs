using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {
	[SerializeField] private GameObject fireeffect1;
	[SerializeField] private GameObject fireeffect2;
	[SerializeField] private GameObject spawn;
	[SerializeField] public int Bullet;
	[SerializeField] public int Bulletbox;
	[SerializeField] private GameObject Target;
	[SerializeField] private  TargetScript enemy;
	[SerializeField] private GameObject Headmarker;
	[SerializeField] private GameObject Marker;
	[SerializeField] private ScoreScript ScoreManager;
	[SerializeField] private GameObject camera;
	[SerializeField] private GameObject Scope;
	[SerializeField] private GameObject ScopeCamera;
	[SerializeField] private bool IsScope;
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
		Scope.SetActive (false);
		}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("r") && Bulletbox > 0 ) {
			Reload ();
				}

		coolTime -= Time.deltaTime;
		Target.GetComponent<TargetScript> ();
		if (Input.GetMouseButtonDown (0) && coolTime <=0f && Bullet !=0) { //!＝０にすることで０じゃないときうてて、０のときうてない
			Ray ray = new Ray (camera.transform.position ,camera.transform.forward);
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
				float dis = Vector3.Distance (Marker.transform.position, hitpoint);

				if(enemy !=null){
					TargetScript t =Target.GetComponent<TargetScript> ();
					t.TargetControl ();
					ScoreManager.Scoreplus (dis);

				}
			}
		}
		if (Input.GetMouseButtonDown (1)) {
			ScopeMethod ();
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
	void ScopeMethod () {
		Camera camera = ScopeCamera.GetComponent<Camera> ();
		if (!IsScope) { //Scopeがfalseの場合。
			Scope.SetActive (true);
			IsScope = true;
			camera.fieldOfView = 30;
		} else {
			Scope.SetActive (false);
			IsScope = false;
			camera.fieldOfView = 60;
		}
		
	}

}
