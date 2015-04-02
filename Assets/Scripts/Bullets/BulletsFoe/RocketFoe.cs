using UnityEngine;
using System.Collections;

public class RocketFoe : FoeBullet {
	[HideInInspector]
	public GameObject targetPlayer;

	protected override void OnTriggerEnter (Collider other) {
		base.OnTriggerEnter (other);
		if (other.tag == "Earth")  {
			ExplosionInstanciated = Instantiate(ExplosionGameObject, transform.position, transform.rotation) as GameObject;
			ExplosionInstanciated.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
			DestroyObject(gameObject);
		}
	}

	protected virtual void Update () {
		if(targetPlayer != null) {
			Quaternion rotation = Quaternion.LookRotation(targetPlayer.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5.0f);
			transform.Translate(Vector3.forward * ProjectileSpeed * Time.deltaTime);
		}
		else
		{
			base.Update();
		}
	}
}
