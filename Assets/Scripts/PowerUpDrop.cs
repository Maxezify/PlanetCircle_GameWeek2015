using UnityEngine;
using System.Collections;

public class PowerUpDrop : MonoBehaviour {

	public GameObject PowerUpBullet;
	// Use this for initialization
	void Start () {
		transform.LookAt(GameObject.FindGameObjectWithTag("Earth").transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.back * Time.deltaTime*0.2f);
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player") {
			other.GetComponent<PlayerBoardsManager>().bulletPrefab = PowerUpBullet;
			Destroy(gameObject);
		}
	}
}
