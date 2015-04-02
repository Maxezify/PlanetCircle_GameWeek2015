using UnityEngine;
using System.Collections;

public class ResizeEffect : MonoBehaviour {

	public float delay;
	float timer;
	void Update() {
		timer += 0.1f;
		if(timer >= delay){
			transform.localScale += new Vector3(0.1f,0.1f,0.1f);
		}
	}
}
