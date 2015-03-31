using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
	public int life;
	public int attackSpeed;
	public int speed;
	public GameObject derp;
	protected GameObject shootInstanciated;
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

	public virtual void Fire () {

	}


}
