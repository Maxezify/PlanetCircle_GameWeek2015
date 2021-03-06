﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EarthManager : MonoBehaviour {

	public float rotSpeed;
	public int life;
	public int lifeMax;
	public List<Material> Surface = new List<Material>();
	public List<Material> Shaders = new List<Material>();
	public List<Material> Fonds = new List<Material>();
	private bool destroy = false;

	private static EarthManager instance;

	public static EarthManager GetInstance()
	{
		if (instance == null)
			instance = new EarthManager();
		return instance;
	}
	// Use this for initialization
	void Start () {
		GameObject.Find("fond").transform.gameObject.GetComponent<Renderer>().material = Fonds[(int)Mathf.Floor(Random.Range (0,Fonds.Count-1))];
		float rand = Random.Range (0,1f);
		bool projector;
		if(rand >=0.5f)
			projector = true;
		else
			projector = false;

		transform.GetChild(0).gameObject.SetActive(projector);

		if(projector){
			//Debug.Log (transform.GetChild(0).GetComponent<Projector>().material.shader);
			transform.GetChild(0).GetComponent<Projector>().material = Shaders[(int)Mathf.Floor(Random.Range (0,Shaders.Count-1))];
		}

		GetComponent<Renderer>().material = Surface[(int)Mathf.Floor(Random.Range (0,Surface.Count-1))];
		rotSpeed = Random.Range(-10f,10f);
		life = lifeMax;
		instance = this;

	}
	
	// Update is called once per frame
	void Update () {
		EarthMovement();

		if(destroy == true){
			if(transform.GetChild (1).gameObject.transform.GetChild (transform.GetChild (1).gameObject.transform.childCount-1).GetComponent<ParticleSystem>().isStopped == true){
				transform.GetChild (1).gameObject.SetActive(false);
				Destroy(gameObject);
				GameManager.GG();
				destroy = false;
			}
		}
	}

	void EarthMovement() {

		transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.World);

	}

	public void TakeDamage(int damages) {
		life -= damages;
		if (life <= Mathf.Floor(lifeMax/2)) {
			//GameManager.GetInstance().MidLifeBehavior();
			//Debug.Log("Midlife");
		}
		if (life <= Mathf.Floor(lifeMax/4)) {
			//Debug.Log("Quarterlife ?");
		}
		if (life <= 0) {
			//Debug.Log("You Win");
			transform.GetChild (1).gameObject.SetActive(true);
			transform.GetComponent<MeshRenderer>().enabled = false;
			GameManager.DestroyGameObjectsWithTag("Enemy");
			destroy = true;

		}
	}
}
