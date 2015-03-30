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

	}

	void InputFire()  {

		if (Input.GetButtonDown("Fire1"))	{

			FireBullet();

		}
	}

	void FireBullet() {

		Vector3 posis = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		
		Instantiate(bulletPrefab, posis, transform.rotation);

		}

	}

