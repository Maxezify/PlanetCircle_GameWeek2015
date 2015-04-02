using UnityEngine;
using System.Collections;

public abstract class FoeBullet : BulletManager {

	protected override void Start() {
		base.Start();
	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}
	
	protected override void OnTriggerEnter (Collider other) {
		base.OnTriggerEnter (other);
		if (other.tag == "Player")  {
			other.gameObject.GetComponent<PlayerBoardsManager>().TakeDamage(damages);
			ExplosionInstanciated = Instantiate(ExplosionGameObject, transform.position, transform.rotation) as GameObject;
			ExplosionInstanciated.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
			DestroyObject(gameObject);
		}
		else
		{

		}
	}
	protected virtual void Update () {
		transform.Translate(Vector3.up * ProjectileSpeed * Time.deltaTime);
	}
}
