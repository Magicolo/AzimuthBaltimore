using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class ShootParticleOnMessage : ComponentBehaviour, IMessageable
{
	public MessageEnum Message;
	public ParticleContainer Container;

	[Inject("Main")]
	readonly Camera mainCamera = null;

	void Shoot()
	{
		var particle = Container.Pop();

		if (particle != null && particle.HasTransform())
		{
			var target = mainCamera.GetMouseWorldPosition(CachedTransform.position.z);
			var direction = (target - CachedTransform.position).normalized;
			particle.GetTransform().rotation = Quaternion.LookRotation(direction);
			particle.SendMessage(Message.Value);
		}
	}

	void OnDrawGizmos()
	{
		if (mainCamera == null)
			return;

		var target = mainCamera.GetMouseWorldPosition(CachedTransform.position.z);
		var direction = target - CachedTransform.position;

		Gizmos.DrawSphere(target, 0.25f);
		Gizmos.DrawCube(target + direction.normalized, new Vector3(0.25f, 0.25f, 0.25f));
	}

	void IMessageable.OnMessage<TId>(TId message)
	{
		if (Message.Equals(message))
			Shoot();
	}
}