﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{

	private int currentLevel;

	public List<GameObject> Enemies = new List<GameObject>();
	private List<GameObject> Pool = new List<GameObject>();
	public GameObject planet;
	private float timer = 0;

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
		OPTIONS,
		NEXTLEVEL
	};
	void Start(){

		if(PlayerPrefs.HasKey("Level")){
			currentLevel = PlayerPrefs.GetInt("Level");
		}else{
			PlayerPrefs.SetInt("Level", 1);
			currentLevel = PlayerPrefs.GetInt("Level");
		}
		//gameState = StateType.GAMESTART;
	}

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
			GameStart(currentLevel);
			break;
		case StateType.PLAYING:
			break;
		case StateType.GAMEOVER:
			StartCoroutine(waitBeforeRespawn());
			gameState = StateType.RESPAWN;
			break;
		case StateType.RESPAWN:
			StartCoroutine(ChangeLevel(currentLevel));
			break;
		case StateType.PAUSE:
			
			break;
		case StateType.UNPAUSE:
			gameState = StateType.PLAYING;
			break;
		case StateType.NEXTLEVEL:
			//StartCoroutine(ChangeLevel(PlayerPrefs.GetInt("Level")));
			StartCoroutine(ChangeLevel(0));
			break;
		default:
			break;
		}  


		timer+=0.1f;

		if(timer >= currentLevel+20f){
			SpawnEnnemies(currentLevel);
			timer = 0;
		}

	}

	public void GameStart(int currentLevel){
		//Au start de chaque niveau, utilisé pour initialiser les vagues and shit
		SpawnPlanet(currentLevel);
		SpawnEnnemies(currentLevel);
		gameState = StateType.PLAYING;
	}

	public static void GameOver(){
		gameState = StateType.GAMEOVER;
	}

	public static void GG(){
		PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+1 );
		gameState = StateType.NEXTLEVEL;
	}

	public void SpawnEnnemies(int nbr){
		//nbr == currentlevel pour le moment
		for(int i = 0; i< nbr+1;i++){
			//!!CHANGER LA ROTATION DE DEPART
			Quaternion quat = Quaternion.identity;
			quat.eulerAngles = new Vector3(0,0,Random.Range (0,360f));
			GameObject go = Instantiate(Enemies[(int)Mathf.Floor(Random.Range(0, Enemies.Count))], new Vector3(0,0,0), quat) as GameObject;
			Pool.Add (go);
		}
	}

	public void SpawnPlanet(int currentLevel){
		//!!PLANETE ALEATOIRE VISUELLEMENT PV en fonction du currentLevel
		GameObject go = Instantiate(planet) as GameObject;
		go.GetComponent<EarthManager>().lifeMax = currentLevel+3;
	}

	IEnumerator waitBeforeRespawn(){

		Fade.In();

		yield return new WaitForSeconds(1.0f);

		yield return new WaitForSeconds(1.0f);
		
		yield return new WaitForSeconds(1.0f);

		Fade.Out();

	}

	IEnumerator ChangeLevel(int levelName){
		Pool.Clear ();
		currentLevel = levelName;
		AsyncOperation operation = Application.LoadLevelAsync(levelName);
		yield return operation;
	}

	void OnLevelWasLoaded(int lvl){
		if(lvl == currentLevel){
			timer = 0;
			gameState = StateType.GAMESTART;
		}
	}

}