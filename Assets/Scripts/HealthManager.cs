using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {
	private int life;
	private static HealthManager instance;
	private int currentHealth;

	public GameObject image;

	private ArrayList hearts = new ArrayList();
	
	// Spacing:
	private int heigh = 50;
	// Use this for initialization

	public static HealthManager GetInstance()
	{
		if (instance == null)
			instance = new HealthManager();
		return instance;
	}
	void Start () {
		instance = this;
		life = 6;
		AddHearts (life);


	}
	
	// Update is called once per frame
	void Update () {
		//life = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBoardsManager>().life;
	}

	public void AddHearts(int n) {
		for (int i = 0; i <n; i ++) { 
			GameObject o = Instantiate(image, transform.position,Quaternion.identity) as GameObject; // Creates a new heart
			Transform newHeart = o.transform;
			newHeart.position = new Vector3(transform.position.x, transform.position.y - (i*0.5f) , transform.position.z);
		}
	
	}

	public void UpdateLife () {

	}
}
