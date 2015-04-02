using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {
	private int life;
	private static HealthManager instance;

	public GameObject image;
	public GameObject StartEffectGameObject;
	private GameObject StartInstanciated;

	public GameObject[] heartsArray;

	protected GameObject heartclone;
	protected GameObject oldHeartClone;

	public static HealthManager GetInstance()
	{
		if (instance == null)
			instance = new HealthManager();
		return instance;
	}
	void Start () {
		instance = this;
		oldHeartClone = gameObject;
		life = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBoardsManager>().life;
		heartsArray = new GameObject[life];
		this.gameObject.transform.position = new Vector3 (-2.5f, 2f, 0);
		//AddHearts (life);
		for (int i = 0; i < life; i++) {
			AddHeart (i);
		}

	}

	void Update () {

	}

	public void AddHeart(int n) {
		if(StartEffectGameObject != null)
		{
			StartInstanciated = Instantiate(StartEffectGameObject, transform.position, transform.rotation) as GameObject;
		}
		heartclone = Instantiate (image, transform.position, Quaternion.identity) as GameObject;
		heartclone.transform.parent = oldHeartClone.transform;
		heartclone.transform.position = new Vector3(transform.position.x, transform.position.y -0.5f * gameObject.transform.childCount, transform.position.z);
		Debug.Log (gameObject.transform.childCount);
		heartsArray [n] = heartclone;
	}

	public void RemoveHeart(int n) {
		DestroyObject (heartsArray [n]);
		//Debug.Log (heartsArray [gameObject.transform.childCount]);

	}


}
