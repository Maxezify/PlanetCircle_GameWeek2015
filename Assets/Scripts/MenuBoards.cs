using UnityEngine;
using System.Collections;

public class MenuBoards : MonoBehaviour {

	public float rotSpeedBoards = -2f;

	
	// Update is called once per frame
	void Update () {

		BoardsMovement();
	
	}

	void BoardsMovement() {
		
		transform.Rotate(0, rotSpeedBoards * Time.deltaTime, 0, Space.World);
		
	}
}
