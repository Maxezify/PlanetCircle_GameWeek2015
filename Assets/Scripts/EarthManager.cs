using UnityEngine;
using System.Collections;

public class EarthManager : MonoBehaviour {

	public float rotSpeed = -10f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		EarthMovement();
	}

	void EarthMovement() {

		transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.World);

	}
}
