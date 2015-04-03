using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

	void doYouEven(){
		PlayerPrefs.SetInt("Difficulty",1);
		GameManager.NewGame();
	}
}
