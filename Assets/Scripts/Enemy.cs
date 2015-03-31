using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
	public int life;
	public int attackSpeed;
	public int speed;
	public GameObject shoot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void Fire () {

	}
}
