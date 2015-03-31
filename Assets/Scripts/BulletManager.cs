using UnityEngine;
using System.Collections;

public abstract class BulletManager : MonoBehaviour {

	public int ProjectileSpeed = 1;
	public GameObject ExplosionGameObject;
	public GameObject StartEffectGameObject;
	public GameObject StartInstanciated;

	// Use this for initialization
	protected virtual void Start () {
		StartInstanciated = Instantiate(StartEffectGameObject, transform.position, transform.rotation) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * ProjectileSpeed * Time.deltaTime);
	}

	void OnTriggerEnter ( Collider other )  {
		
		if (other.tag == "Enemy" || other.tag == "Earth")  {
			Instantiate(ExplosionGameObject, transform.position, transform.rotation);
			DestroyObject(gameObject);
			
		}
}
}
