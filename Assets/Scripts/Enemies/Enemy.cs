using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
	public int life;
	public int timer = 0;
	public int attackSpeed;
	public int speed;
	public GameObject shoot;
	protected GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected void FindPlayer () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public virtual void Move () {

	}

	public virtual void TakeDamage(int damages) {
		life -= damages;

		if (life <= 0) {
			Death ();
		}
	}

	public virtual void Death() {
		DestroyObject(gameObject);
	}

	public virtual void Fire () {

	}


}
