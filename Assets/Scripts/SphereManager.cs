using UnityEngine;
using System.Collections;

public class SphereManager : MonoBehaviour {

	private float rotSpeed = 75f;
	private float velocitySpeed = 120f;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {

		InputManager();
	
	}

	void InputManager() {
		
		if (Input.GetKey(KeyCode.RightArrow))	{
			
			Debug.Log("Je passe");
			rb.AddTorque(0, 0, velocitySpeed * Time.deltaTime);
			transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
			
		}

		if (Input.GetKey(KeyCode.LeftArrow))	{
			
			Debug.Log("Je passe");
			rb.AddTorque(0, 0, velocitySpeed * Time.deltaTime);
			transform.Rotate(0, 0, -rotSpeed * Time.deltaTime);
			
		}

}
}
