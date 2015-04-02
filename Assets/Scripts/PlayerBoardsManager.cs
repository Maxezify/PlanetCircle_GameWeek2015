using UnityEngine;
using System.Collections;

public class PlayerBoardsManager : MonoBehaviour {

	public GameObject bulletPrefab;
	public int life;
	public string actualBonus;
	public GameObject[] clonePlaceArray = new GameObject[3];
	public GameObject[] cloneArray = new GameObject[3];
	protected GameObject cloneInstanciated;
	public bool isClone;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		InputFire();

		InputClone ();
		//InputGetClone();

	}


	void InputFire()  {

		if (Input.GetButtonDown("Fire") || Input.GetAxis("FirePad")>0)	{

			FireBullet();

		}
	}

	void InputClone()  {
		if (!isClone) {
			if (life > 1) {
				if (Input.GetKeyDown (KeyCode.A)||Input.GetButtonDown("XPad")) {
					PlaceClone(0);
				}
				if (Input.GetKeyDown (KeyCode.Z)||Input.GetButtonDown("YPad")) {
					PlaceClone(1);
				}
				if (Input.GetKeyDown (KeyCode.E)||Input.GetButtonDown("BPad")) {
					PlaceClone(2);
				}
			}
		}
	}

	void FireBullet() {

		Vector3 posis = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		
		Instantiate(bulletPrefab, posis, transform.rotation);

	}

	void PlaceClone (int i) {
		if (cloneArray[i] == null) {
			cloneArray[i] = CreateClone (clonePlaceArray [i]);
			life --;
		} else {
			DestroyObject(cloneArray[i]);
			cloneArray[i] = null;
			life ++;
		}
	}

	GameObject CreateClone(GameObject clonePlace) {
		cloneInstanciated = Instantiate (gameObject, clonePlace.transform.position, clonePlace.transform.rotation) as GameObject;
		cloneInstanciated.GetComponent<PlayerBoardsManager> ().isClone = true;
		cloneInstanciated.transform.parent = transform.parent;
		cloneInstanciated.GetComponent<PlayerBoardsManager> ().life = 1;
		return cloneInstanciated;
	}
	/*
	void InputGetClone()	{

		if (Input.GetButtonDown("ATouch"))	{

		}
	} */
	public void TakeDamage(int damages) {
		life -= damages;
		HealthManager.GetInstance ().UpdateLife ();
		if (life <= 0) {
			Death ();
		}
	}
	
	public virtual void Death() {
		DestroyObject(gameObject);
	}

}

