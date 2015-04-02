using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{

	private int currentLevel = 0;
	static StateType gameState = StateType.GAMESTART;

	private static GameManager _instance;

	public static GameManager instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<GameManager>();
				
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}

	public enum StateType
	{
		DEFAULT,      //Fall-back
		PAUSE,
		UNPAUSE,//waiting
		PLAYING,      
		GAMEOVER,
		GAMESTART,
		RESPAWN,
		MENU,         
		OPTIONS       
	};

	void Awake() 
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			//Debug.Log ("NOOOOOOOOOOOOOOOOOOOOOOOOOO");
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			Destroy(gameObject);
		}
	}

	void Update(){
		//Debug.Log (gameState);
		
		switch(gameState){
		case StateType.GAMESTART:
			break;
		case StateType.PLAYING:
			break;
		case StateType.GAMEOVER:
			StartCoroutine(waitBeforeRespawn());
			gameState = StateType.RESPAWN;
			break;
		case StateType.RESPAWN:
			//Restart a changer
			Application.LoadLevel(0);
			//StartCoroutine(ChangeLevel(0));
			gameState = StateType.PLAYING;
			break;
		case StateType.PAUSE:
			
			break;
		case StateType.UNPAUSE:
			gameState = StateType.PLAYING;
			break;
		case StateType.MENU:
			
			break;
		default:
			break;
		}  
	}

	public static void GameOver(){
		gameState = StateType.GAMEOVER;
	}

	IEnumerator waitBeforeRespawn(){

		Fade.In();

		yield return new WaitForSeconds(1.0f);
		
		yield return new WaitForSeconds(1.0f);
		
		yield return new WaitForSeconds(1.0f);
		Fade.Out();
	}

	IEnumerator ChangeLevel(int levelName){
		currentLevel = levelName;
		AsyncOperation operation = Application.LoadLevelAsync(levelName);
		//gameState = StateType.GAMESTART;
		yield return operation;
		
	}


}