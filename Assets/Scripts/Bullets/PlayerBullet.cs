using UnityEngine;
using System.Collections;

public abstract class PlayerBullet : BulletManager {

	void OnBecameInvisible() {
		Destroy(gameObject);
	}

	protected override void Start() {
		base.Start();
		//StartInstanciated.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
	}

	protected override void OnTriggerEnter (Collider other) {
		base.OnTriggerEnter (other);
		if (other.tag == "Enemy")  {
			other.gameObject.GetComponent<Enemy>().TakeDamage(damages);
		}
		if (other.tag == "Earth")  {
			other.gameObject.GetComponent<EarthManager>().TakeDamage(damages);
		}
		if(other.tag == "Player" || other.tag == "PowerUp" || other.tag == "Bullet") {

		}
		else {
			ExplosionInstanciated = Instantiate(ExplosionGameObject, transform.position, transform.rotation) as GameObject;
			ExplosionInstanciated.transform.position = new Vector3(transform.position.x, transform.position.y, -0.2f);
			DestroyObject(gameObject);
		}

	}
}
