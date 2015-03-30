using UnityEngine;
using System.Collections;

public class PlayerBoardsManager : MonoBehaviour {

	private float rotSpeed = 20f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		InputManager();

	
	}

	void InputManager() {

		if (Input.GetKeyDown ("space"))	{

			Debug.Log("Je passe");
			transform.Rotate(0, 0, rotSpeed * Time.deltaTime);

		}

	}
}
