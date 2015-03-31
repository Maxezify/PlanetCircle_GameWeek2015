using UnityEngine;
using System.Collections;

public class ParticleLifeTime : MonoBehaviour {

	public float lifetime;
	float timeBeforeDeath;



	void Update() {
		timeBeforeDeath++;

		if(timeBeforeDeath >= lifetime)
		{
			Destroy (gameObject);
		}
	}
}
