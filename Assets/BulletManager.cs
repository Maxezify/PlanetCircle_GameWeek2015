using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour {

	private int ProjectileSpeed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.up * ProjectileSpeed * Time.deltaTime);


	
	}

	void OnTriggerEnter ( Collider other )  {
		
		if (other.tag == "Earth")  {
			
			DestroyObject(gameObject);
			
		}
}
}
