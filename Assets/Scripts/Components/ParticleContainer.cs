using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class ParticleContainer : ComponentBehaviour
{
	[Min]
	public int Capacity;
	public int Count
	{
		get { return particles.Count; }
	}

	readonly List<IEntity> particles = new List<IEntity>();

	[Inject]
	readonly IEntityManager entityManager = null;
	readonly Action<IEntity> onEntityRemoved;

	public ParticleContainer()
	{
		onEntityRemoved = OnEntityRemoved;
	}

	public void Add(IEntity entity)
	{
		if (particles.Count >= Capacity)
			throw new ArgumentOutOfRangeException();

		var transform = entity.GetTransform();

		if (transform != null)
		{
			transform.parent = CachedTransform;
			transform.localPosition = Vector3.zero;
		}

		particles.Add(entity);
	}

	public void Remove(IEntity entity)
	{
		var transform = entity.GetTransform();

		if (transform != null)
			transform.parent = null;

		particles.Remove(entity);
	}

	public IEntity Pop()
	{
		if (particles.Count == 0)
			return null;

		var entity = particles.PopLast();

		if (entity != null)
		{
			var transform = entity.GetTransform();

			if (transform != null)
				transform.parent = null;
		}

		return entity;
	}

	[Message(ComponentMessages.OnAdded)]
	void OnAdded()
	{
		entityManager.Entities.OnEntityRemoved += onEntityRemoved;
	}

	[Message(ComponentMessages.OnRemoved)]
	void OnRemoved()
	{
		for (int i = 0; i < particles.Count; i++)
		{
			var particle = particles[i];

			if (particle.HasBehaviour())
				entityManager.RecycleEntity(particles[i].GetBehaviour());
			else
				entityManager.RecycleEntity(particle);
		}

		particles.Clear();
		entityManager.Entities.OnEntityRemoved -= onEntityRemoved;
	}

	void OnEntityRemoved(IEntity entity)
	{
		particles.Remove(entity);
	}
}