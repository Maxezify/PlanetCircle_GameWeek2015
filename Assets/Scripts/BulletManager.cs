using UnityEngine;
using System.Collections;

public abstract class BulletManager : MonoBehaviour {

	public int ProjectileSpeed = 1;
	public GameObject ExplosionGameObject;
	public GameObject StartEffectGameObject;
	public GameObject StartInstanciated;
	public int damages;

	// Use this for initialization
	protected virtual void Start () {
		StartInstanciated = Instantiate(StartEffectGameObject, transform.position, transform.rotation) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * ProjectileSpeed * Time.deltaTime);
	}

	protected virtual void OnTriggerEnter ( Collider other )  {
		Instantiate(ExplosionGameObject, transform.position, transform.rotation);
		DestroyObject(gameObject);
}
}
