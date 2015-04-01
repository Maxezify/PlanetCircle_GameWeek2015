using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	Text Score;
	private int life;


	// Use this for initialization
	void Start () {

		Score = GetComponent<Text>();
		life = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBoardsManager>().life;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
		
		
	}
