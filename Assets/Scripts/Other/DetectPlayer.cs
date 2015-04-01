using UnityEngine;
using System.Collections;

public class DetectPlayer : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			transform.root.GetComponent<RocketFoe>().targetPlayer = other.gameObject;
		}
	}
}
