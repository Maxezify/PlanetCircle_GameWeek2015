using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
	public int life;
	public int timer = 0;
	public int attackSpeed;
	public int speed;
	public GameObject shoot;
	public GameObject dropPowerUp;
	protected GameObject player;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	protected virtual void Update () {
		Move ();
	}

	protected void FindPlayer () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public virtual void Move () {
		transform.root.Rotate(0, 0, speed * Time.deltaTime);
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
		DestroyObject(gameObject);
	}

	public virtual void Fire () {

	}

}
