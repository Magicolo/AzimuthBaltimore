using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class ExplodeOnMessage : ComponentBehaviour, IMessageable
{
	public MessageEnum Message;
	public EntityMessage OnExploded = new EntityMessage(GameMessages.OnExploded, MessagePropagation.UpwardsInclusive);
	public ParticleEffect Explosion;

	[Inject]
	readonly IParticleManager particleManager = null;

	public void OnMessage<TId>(TId message)
	{
		if (Message.Equals(message))
		{
			particleManager.CreateEffect(Explosion, CachedTransform.position);
			Entity.SendMessage(OnExploded);
		}
	}
}