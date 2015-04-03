using UnityEngine;
using System.Collections;

public class RotatePlanet : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 5* Time.deltaTime, 0, Space.World);
	}
}
