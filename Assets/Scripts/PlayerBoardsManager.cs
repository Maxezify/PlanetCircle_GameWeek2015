using UnityEngine;
using System.Collections;

public class PlayerBoardsManager : MonoBehaviour {

	public GameObject bulletPrefab;


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

	}

