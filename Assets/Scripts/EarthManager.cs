﻿using UnityEngine;
using System.Collections;

public class EarthManager : MonoBehaviour {

	public float rotSpeed = -10f;
	public int life;
	public int lifeMax;

	// Use this for initialization
	void Start () {
		lifeMax = life;
	}
	
	// Update is called once per frame
	void Update () {

		EarthMovement();
	}

	void EarthMovement() {

		transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.World);

	}

	public void TakeDamage(int damages) {
		life -= damages;
		if (life <= Mathf.Floor(lifeMax/2)) {
			Debug.Log("Midlife");
		}
		if (life <= Mathf.Floor(lifeMax/4)) {
			Debug.Log("Quarterlife ?");
		}
		if (life <= 0) {
			Debug.Log("You Win");
			GameManager.GameOver();
		}
	}
}
