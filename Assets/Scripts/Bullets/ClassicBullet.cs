using UnityEngine;
using System.Collections;

public class ClassicBullet : BulletManager {

	protected override void Start() {
		base.Start();
		StartInstanciated.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
	}

	protected override void OnTriggerEnter (Collider other) {
		base.OnTriggerEnter (other);
		if (other.tag == "Enemy")  {
			other.gameObject.GetComponent<Enemy>().TakeDamage(damages);
		}
	}
}
