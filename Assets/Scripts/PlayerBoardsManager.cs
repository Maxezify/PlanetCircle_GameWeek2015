using UnityEngine;
using System.Collections;

public class PlayerBoardsManager : MonoBehaviour {

	public GameObject bulletPrefab;
	public int life;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		InputFire();

		InputGetClone();

	}

	void InputFire()  {

		if (Input.GetButtonDown("Fire"))	{

			FireBullet();

		}
	}

	void FireBullet() {

		Vector3 posis = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		
		Instantiate(bulletPrefab, posis, transform.rotation);

		}

	void InputGetClone()	{

		if (Input.GetButtonDown("ATouch"))	{

		}


	}
	public void TakeDamage(int damages) {
		life -= damages;
		
		if (life <= 0) {
			Death ();
		}
	}
	
	public virtual void Death() {
		DestroyObject(gameObject);
	}

}

