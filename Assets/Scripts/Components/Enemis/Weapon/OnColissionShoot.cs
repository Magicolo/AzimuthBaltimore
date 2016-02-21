using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class OnColissionShoot : ComponentBehaviour
{
	public EntityBehaviour ProjectilePrefab;
	public Transform WeaponRoot;
	public TimeComponent Time;
	public float CoolDown;
	float t;

	void OnTriggerStay(Collider other)
	{
		if (t <= 0)
			shoot();
	}

	void shoot()
	{
		t = CoolDown;
		IEntity entity = Entity.Manager.CreateEntity(ProjectilePrefab);
		entity.GetTransform().position = WeaponRoot.position;
		var target = entity.GetComponent<Vector3Target>();

	}

	void Update()
	{
		if (t > 0)
			t -= Time.DeltaTime;

	}
}