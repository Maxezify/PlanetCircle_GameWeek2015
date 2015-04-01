using UnityEngine;
using System.Collections;

public class EnemyShield : Enemy {

	public GameObject GeneratedShield;
	public GameObject BreakShieldEffect;

	public override void Death() {
		base.Death();
		Instantiate(BreakShieldEffect, GeneratedShield.transform.position, Quaternion.identity);
		Destroy(GeneratedShield);
	}
}
