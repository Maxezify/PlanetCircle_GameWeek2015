using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
	public int life;
	public int timer = 0;
	public int attackSpeed;
	public int speed;
	public GameObject shoot;
	public GameObject dropPowerUp;
	public GameObject player;
	public bool lookAtThePlayer;
	public GameObject spawnEffect;
	
	// Use this for initialization
	protected virtual void Start () {
		if(spawnEffect != null) {
			Instantiate(spawnEffect, transform.position, transform.rotation);
		}
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		Move ();
	}

	protected void FindPlayer () {
		//player = GameObject.FindGameObjectWithTag ("Player");
	}

	public virtual void Move () {
		if(transform.root != null)
		{
			transform.root.Rotate(0, 0, speed * Time.deltaTime);
		}
	}

	public virtual void TakeDamage(int damages) {
		life -= damages;

		if (life <= 0) {
			Death ();
		}
	}

	public virtual void Death() {
		if(dropPowerUp != null)
		{
			Instantiate(dropPowerUp,transform.position, Quaternion.identity);
		}
		DestroyObject(transform.root.gameObject);
	}

	public virtual void Fire () {

	}

}
