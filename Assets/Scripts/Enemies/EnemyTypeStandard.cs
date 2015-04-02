﻿using UnityEngine;
using System.Collections;

public class EnemyTypeStandard : Enemy {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
		if (timer == attackSpeed) {
			Fire ();
			timer = 0;
		} else {
			timer ++;
		}
	}

	public override void Fire ()
	{
		base.Fire ();
		Vector3 posis = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		
		Instantiate(shoot, posis, transform.rotation);
		
	}
}