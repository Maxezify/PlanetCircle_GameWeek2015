using UnityEngine;
using System.Collections;

public class LaserBulletPlayer : PlayerBullet {
	private float timer;

	void Start(){
		timer = 0;
	}

	public void OnParticleCollision (GameObject other) {
		timer += 0.1f;
		if (other.tag == "Enemy")  {
			if(timer >= 1.0f){
				other.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Enemy>().TakeDamage(damages);
				timer = 0;
			}
		}
		if (other.tag == "Shield")  {
			if(timer >= 1.0f){
				other.transform.GetChild(0).gameObject.GetComponent<Enemy>().TakeDamage(damages);
				timer = 0;
			}
		}
		if (other.tag == "Earth")  {
			if(timer >= 1.0f){
				other.GetComponent<EarthManager>().TakeDamage(damages);
				timer = 0;
			}
		}
		if(other.tag == "Player" || other.tag == "PowerUp" || other.tag == "Bullet") {
			
		}
	}
}
