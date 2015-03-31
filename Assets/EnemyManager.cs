using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public float life = 5f;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerEnter ( Collider other )  {
		
		if (other.tag == "Bullet")  {

		}

}

}
