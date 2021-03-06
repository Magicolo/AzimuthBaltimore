﻿using UnityEngine;
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
			var transform = particle.GetTransform();
			var direction = (Input.mousePosition - mainCamera.WorldToScreenPoint(transform.position)).normalized;
			direction.z = direction.y;
			direction.y = 0f;
			particle.SendMessage(GameMessages.OnShot, direction.normalized, MessagePropagation.DownwardsInclusive);
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