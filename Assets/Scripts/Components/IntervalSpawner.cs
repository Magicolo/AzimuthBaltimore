using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class IntervalSpawner : ComponentBehaviour
{
	public float Interval = 1f;
	public int MaxSpawn;
	public Transform Parent;
	public EntityBehaviour Spawn;
	public TimeComponent Time;

	float counter;
	[Inject]
	readonly IEntityManager entityManager = null;

	void Update()
	{
		counter += Time.DeltaTime;

		if (counter >= Interval)
		{
			var entity = entityManager.CreateEntity(Spawn);
			var transform = entity.GetTransform();
			transform.parent = Parent;
			transform.localPosition = Vector3.zero;

			counter -= Interval;
		}
	}
}