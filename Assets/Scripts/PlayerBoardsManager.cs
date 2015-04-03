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
	public bool laser = false;
	public bool lasering = false;
	private GameObject lazor;
	private int fireTimer = 0;
	public int fireRate;
	private int clonetimer = 0;
	public int cloneRate;

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
		if(laser){
			if (Input.GetButton("Fire") || Input.GetAxis("FirePad")>0)	{
				if(!lasering){
					Vector3 posis = transform.position;
					lazor = Instantiate(bulletPrefab, posis, transform.parent.transform.rotation) as GameObject;
					lazor.transform.LookAt(new Vector3(0,0,lazor.transform.position.z));
					lazor.transform.SetParent(transform);
					lasering = true;
				}
			}else if(lasering == true){
				lasering = false;
				Destroy (lazor);
			}
		}else{
			if (fireTimer >= fireRate) {
				if (Input.GetButtonDown ("Fire") || Input.GetAxis ("FirePad") > 0) {
					if (bulletPrefab.name == "RocketBulletPlayer") {
						FireBullet ();
						FireBullet ();
						FireBullet ();
					} else {
						FireBullet ();
						fireTimer = 0;
					} 
				} else fireTimer ++;
			}
		}
	}

	void InputClone()  {
		if (clonetimer >= cloneRate) {
			if (!isClone) {
				if (Input.GetKeyDown (KeyCode.A)||Input.GetButtonDown("XPad")) {
					PlaceClone(0);
					clonetimer = 0;
				}
				if (Input.GetKeyDown (KeyCode.Z)||Input.GetButtonDown("YPad")) {
					PlaceClone(1);
					clonetimer = 0;
				}
				if (Input.GetKeyDown (KeyCode.E)||Input.GetButtonDown("BPad")) {
					PlaceClone(2);
					clonetimer = 0;
				}
			}

		} else clonetimer ++;
	}

	void FireBullet() {

		Vector3 posis = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		
		Instantiate(bulletPrefab, posis, transform.rotation);

	}

	void PlaceClone (int i) {
		if (cloneArray[i] == null) {
			if (life > 1) {
				cloneArray[i] = CreateClone (clonePlaceArray [i]);
				life --;
				HealthManager.GetInstance().RemoveHeart(life);
			}
		} else {
			DestroyObject(cloneArray[i]);
			cloneArray[i] = null;
			life ++;
			HealthManager.GetInstance().AddHeart(life-1);
		}
	}

	GameObject CreateClone(GameObject clonePlace) {
		cloneInstanciated = Instantiate (gameObject, clonePlace.transform.position, clonePlace.transform.rotation) as GameObject;
		cloneInstanciated.GetComponent<PlayerBoardsManager> ().isClone = true;
		cloneInstanciated.transform.parent = transform.parent;
		cloneInstanciated.GetComponent<PlayerBoardsManager> ().life = 1;
		return cloneInstanciated;
	}

	public void TakeDamage(int damages) {
		Debug.Log (bulletPrefab.name);
		life -= damages;
		if (!isClone) HealthManager.GetInstance ().RemoveHeart (life);

		//HealthManager.GetInstance ().LoseLife ();
		if (life <= 0) {
			if(!isClone)
				GameManager.GameOver();
			else
				Destroy(gameObject);
		}
	}	

	public void ChangeFireRate() {
		if (bulletPrefab.name == "RocketBulletPlayer") {
			fireRate = 45;
		}
		if (bulletPrefab.name == "TripleBulletPlayer") {
			fireRate = 20;
		}
	}
}

