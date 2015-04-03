using UnityEngine;
using System.Collections;

public class Spacedisable : MonoBehaviour {

	public GameObject ButtonPress;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		
		if (Input.GetButtonDown("Space") || Input.GetButtonDown("APad"))	{

			ButtonPress.SetActive(false);
			
			
		}

	
	}
}
