using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class AttackOnMessage : ComponentBehaviour,IMessageable
{
	public EntityBehaviour Weapon;

	public MessageEnum OnMessage;

	void IMessageable.OnMessage<TId>(TId message)
	{
		if (OnMessage.Equals(message))
		{
			Weapon.gameObject.SetActive(true);
		}
	}
}