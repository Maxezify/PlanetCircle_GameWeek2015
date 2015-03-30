using UnityEngine;
using System.Collections;

public class EarthManager : MonoBehaviour {

	float rotSpeed = 10;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		EarthMovement();
	
	}

	void EarthMovement() {

		transform.Rotate(0, 0, rotSpeed * Time.deltaTime, Space.World);


	}
}
