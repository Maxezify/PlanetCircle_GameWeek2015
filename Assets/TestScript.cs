using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestScript : MonoBehaviour {

	public void Start() {
		//EventSystem.current.SetSelectedGameObject(totoG);
		//EventSystem.current.currentSelectedGameObject;
		//EventSystem.current.lastSelectedGameObject;
	}

	public void toto(int i)
	{
		Application.LoadLevel("Gameplay-Clean");
	}
}
