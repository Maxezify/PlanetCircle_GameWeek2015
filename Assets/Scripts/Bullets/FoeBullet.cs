using UnityEngine;
using System.Collections;

public abstract class FoeBullet : BulletManager {

	protected override void Start() {
		base.Start();
		StartInstanciated.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	protected override void OnTriggerEnter (Collider other) {
		base.OnTriggerEnter (other);
		if (other.tag == "Player")  {
			other.gameObject.GetComponent<PlayerBoardsManager>().TakeDamage(damages);
		}
	}
}
