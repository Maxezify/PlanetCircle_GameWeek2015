using UnityEngine;
using System.Collections;

public class OnclickButtonMenu : MonoBehaviour {

	public GameObject Buttonnew;
	public GameObject ButtonContinue;
	public GameObject ButtonPress;


	// Use this for initialization
	void Start () {

		Buttonnew.SetActive(false);
		ButtonContinue.SetActive(false);

	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Space") || Input.GetButtonDown("APad"))	{

			Buttonnew.SetActive(true);
			ButtonContinue.SetActive(true);
			ButtonPress.SetActive(false);


		}

		}

	/*void InputButton()	{

		if (Input.GetButtonDown("Space"))/* || Input.GetButtonDown("APad"))	{
			
			Debug.Log("Je click");
			
			Vector3 PlacementBoutonNew = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			
			Vector3 PlacementBoutonContinue = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			
			Instantiate(ButtonNew, PlacementBoutonNew, transform.rotation);
			
			Instantiate(ButtonContinue, PlacementBoutonContinue, transform.rotation);

			
		}*/


}