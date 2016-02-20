using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class EntityTarget : TargetBase
{

	public override Vector3 Target
	{
		get
		{
			if (HasTarget)
				return TargetedEntity.GetTransform().position;
			else
				return default(Vector3);
		}
	}
	public override bool HasTarget
	{
		get { return TargetedEntity != null; }
	}

	IEntityGroup targetables;
	public IEntity TargetedEntity;
	float counter;
	[Inject]
	readonly IEntityManager entityManager = null;
	readonly Action<IEntity> onTargetRemoved;

	public EntityTarget()
	{
		onTargetRemoved = OnTargetRemoved;
	}

	[Message(ComponentMessages.OnAdded)]
	void OnAdd()
	{
		targetables = entityManager.Entities.Filter(typeof(TransformComponent));
		targetables.OnEntityRemoved += onTargetRemoved;
	}

	[Message(ComponentMessages.OnRemoved)]
	void OnRemoved()
	{
		targetables.OnEntityRemoved -= onTargetRemoved;
	}

	void OnTargetRemoved(IEntity entity)
	{
		if (TargetedEntity == entity)
		{
			TargetedEntity = null;
		}
	}
}