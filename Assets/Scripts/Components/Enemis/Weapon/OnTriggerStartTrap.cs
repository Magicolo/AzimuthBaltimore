using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class OnTriggerStartTrap : ComponentBehaviour
{
	public EntityBehaviour TrapPrefab;
	public Transform TrapRoot;
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
		IEntity entity = Entity.Manager.CreateEntity(TrapPrefab);
		entity.GetTransform().position = TrapRoot.position;
	}

	void Update()
	{
		if (t > 0)
			t -= Time.DeltaTime;
	}
}