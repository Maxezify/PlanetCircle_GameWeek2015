using UnityEngine;
using System.Collections;

public class EnemyShield : Enemy {

	public GameObject GeneratedShield;
	public GameObject BreakShieldEffect;
	private GameObject shield;

	void Start() {
		Quaternion quat = Quaternion.identity;
		quat.eulerAngles = new Vector3(0,0,Random.Range (0,360f));
		shield = Instantiate(GeneratedShield, new Vector3(0,0,0), quat) as GameObject;
	}

	public override void Death() {
		base.Death();
		Instantiate(BreakShieldEffect, shield.transform.GetChild(0).position, shield.transform.GetChild(0).rotation);
		Destroy(shield);
	}
}
