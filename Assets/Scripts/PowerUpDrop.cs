using UnityEngine;
using System.Collections;

public class PowerUpDrop : MonoBehaviour {

	public GameObject PowerUpBullet;
	protected GameObject[] clonesArray;
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
			clonesArray = GameObject.FindGameObjectsWithTag("Player");
			for(int i = 0; i < clonesArray.Length; i++)
			{

				clonesArray[i].GetComponent<PlayerBoardsManager>().bulletPrefab = PowerUpBullet;
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBoardsManager>().ChangeFireRate();
			}
			Destroy(gameObject);
		}
	}
}
