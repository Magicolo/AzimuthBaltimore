using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class ParticleSpawner : ComponentBehaviour
{
	public float Interval = 1f;
	public EntityBehaviour Prefab;
	public ParticleContainer Container;
	public TimeComponent Time;

	float counter;
	[Inject]
	readonly IEntityManager entityManager = null;

	void Update()
	{
		if (Container.Count >= Container.Capacity)
			return;

		counter += Time.DeltaTime;

		if (counter >= Interval)
		{
			Container.Add(entityManager.CreateEntity(Prefab));
			counter -= Interval;
		}
	}
}