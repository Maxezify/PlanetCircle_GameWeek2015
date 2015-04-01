using UnityEngine;
using System.Collections;

public class RocketBulletPlayer : PlayerBullet {

	Vector2 derivesXY;
	// Use this for initialization
	void Start () {
		derivesXY = new Vector2(Random.Range(-2.0f,2.0f), Random.Range(-2.0f,2.0f));
	}
	
	// Update is called once per frame
	protected override void Update () {
		ProjectileSpeed += 1;
		if(ProjectileSpeed <= 10) {
			transform.Translate (Vector3.left * Time.deltaTime * derivesXY [0]);
			transform.Translate (Vector3.up * Time.deltaTime * derivesXY [1]);
		} else if(ProjectileSpeed > 100) {
			Destroy(gameObject);
		} else {
			transform.Translate(Vector3.up * ProjectileSpeed/4 * Time.deltaTime);
		}
	}
}
