using UnityEngine;
using System.Collections;

public class ClassicBullet : BulletManager {

	protected override void Start() {
		base.Start();
		StartInstanciated.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
	}
}
