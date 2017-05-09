using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {
	[SerializeField] private GameObject fireeffect1;
	[SerializeField] private GameObject fireeffect2;
	[SerializeField] private GameObject spawn;
	float coolTime;

	//  this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		coolTime -= Time.deltaTime;
		if (Input.GetMouseButtonDown (0) && coolTime <=0f) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			GameObject obj1 = Instantiate (fireeffect2, spawn.transform.position, Quaternion.identity);
			Destroy (obj1, 0.3f);
			coolTime = 0.5f;

			if (Physics.Raycast (ray, out hit)) { //当たってから処理をする。
					GameObject obj = Instantiate (fireeffect1, hit.point - ray.direction, Quaternion.identity) as GameObject; //位置情報もしっかりと書いておく。
					Destroy (obj, 0.3f);
			}
		}
	}
}