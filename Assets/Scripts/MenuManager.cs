using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	
	private int selection = 1;
	private int frames = 10; // Le temps qu'il faut attendre entre 2 inputs du stick pour sélectionner une option
	private int aframes = 10; // le temps qu'il faut attendre entre 2 inputs du bouton A
	/*Hashtable optionsPlay;
	Hashtable optionsQuit;
	Hashtable options2Play;
	Hashtable options2Quit;*/
	//public GameObject play;
	//public GameObject quit;
	
	public Button Buttonnew;
	public Button ButtonContinue;
	
	//private Vector3 playScaleDefault;
	//private Vector3 quitScaleDefault;
	
	//private Vector3 playScaleModif;
	//private Vector3 quitScaleModif;
	
	//public float multiplier = 1.5f;
	
	// Use this for initialization
	void Start () {
		
		/*playScaleDefault = play.transform.localScale;
		quitScaleDefault = quit.transform.localScale;
		
		playScaleModif = playScaleDefault*multiplier;
		quitScaleModif = quitScaleDefault*multiplier;/*
		
		optionsPlay = iTween.Hash(
			"scale", playScaleModif,
			"time", 0.1f,
			"easetype", iTween.EaseType.linear,
			"oncomplete", "ChangeColor"
			);
		
		optionsQuit = iTween.Hash(
			"scale", quitScaleModif,
			"time", 0.1f,
			"easetype", iTween.EaseType.linear,
			"oncomplete", "ChangeColor"
			);
		
		options2Play = iTween.Hash(
			"scale", playScaleDefault,
			"time", 0.1f,
			"easetype", iTween.EaseType.linear,
			"oncomplete", "ChangeColor"
			);
		
		options2Quit = iTween.Hash(
			"scale", quitScaleDefault,
			"time", 0.1f,
			"easetype", iTween.EaseType.linear,
			"oncomplete", "ChangeColor"
			);*/
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		frames++;
		
		if (frames >= 10)
		{
			if(Input.GetAxis("HorizontalPad") < -0.1f || Input.GetKey(KeyCode.Q))
			{
				selection +=1;
				frames = 1;
			}
			else if(Input.GetAxis("HorizontalPad") > 0.1f || Input.GetKey(KeyCode.D))
			{
				selection -=1;
				frames = 1;
			}
		}
		
		
		if (selection >2)
		{
			selection = 1;
		}
		else if (selection < 1)
		{
			selection = 2;
		}
		
		
		switch (selection)
		{
			
		case 1 :
			/*iTween.ScaleTo(play, optionsPlay);
			iTween.ScaleTo(quit, options2Quit);*/
			Buttonnew.GetComponent<Image>().color = Color.white;
			//ButtonContinue.GetComponent<Button>().colors.pressedColor = false;
			//GameObject.Find("Jouer").iTween.ScaleTo(this.gameObject, options);
			//GameObject.Find("Quit").guiText.color = Color.white;
			break;
			
		case 2 :
			//GameObject.Find("Quit").iTween.ScaleTo(this.gameObject, options);
			//GameObject.Find("Jouer").guiText.color = Color.white;
			//Buttonnew.GetComponent<Button>().colors.pressedColor = false;
			ButtonContinue.GetComponent<Image>().color = Color.white;
			/*iTween.ScaleTo(play, options2Play);
			iTween.ScaleTo(quit, optionsQuit);*/
			break;
			
		}
		
		aframes++;
		if (aframes >= 10)
		{
			if (Input.GetButtonDown("APad") || Input.GetButtonDown("Space"))
			{
				Confirm();
				aframes = 0;
			}
		}
		
		
	}
	
	
	
	void Confirm()
	{
		
		if(selection == 1 && Input.GetButtonDown("Space"))
		{
			Application.LoadLevel("Gameplay-Clean");
		}
		
		else if (selection == 2)
		{
			
		}
		
	}
	
	
}
