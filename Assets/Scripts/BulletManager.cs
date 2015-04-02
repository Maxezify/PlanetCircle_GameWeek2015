using UnityEngine;
using System.Collections;

public abstract class BulletManager : MonoBehaviour {

	public int ProjectileSpeed = 1;
	public GameObject ExplosionGameObject;
	public GameObject StartEffectGameObject;
	protected GameObject StartInstanciated;
	protected GameObject ExplosionInstanciated;
	public int damages;

	// Use this for initialization
	protected virtual void Start () {
		if(StartEffectGameObject != null)
		{
			StartInstanciated = Instantiate(StartEffectGameObject, transform.position, transform.rotation) as GameObject;
		}
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		transform.Translate(Vector3.up * ProjectileSpeed * Time.deltaTime);
	}

	protected virtual void OnTriggerEnter ( Collider other )  {
}
}
