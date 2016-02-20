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

	void Shoot()
	{
		var particle = Container.Pop();

		if (particle != null)
		{

		}
	}

	void IMessageable.OnMessage<TId>(TId message)
	{
		if (Message.Equals(message))
			Shoot();
	}
}