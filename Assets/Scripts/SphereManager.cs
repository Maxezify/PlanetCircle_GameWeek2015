using UnityEngine;
using System.Collections;

public class SphereManager : MonoBehaviour {

	private float rotSpeed = 75f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		InputManager();
	
	}

	void InputManager() {
		
		if (Input.GetKey(KeyCode.RightArrow))	{
			
			Debug.Log("Je passe");
			transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
			
		}

		if (Input.GetKey(KeyCode.LeftArrow))	{
			
			Debug.Log("Je passe");
			transform.Rotate(0, 0, -rotSpeed * Time.deltaTime);
			
		}

}
}
