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

	float t;
	public float Cooldown;

	bool ReadyToAttack;

	void IMessageable.OnMessage<TId>(TId message)
	{
		if (OnMessage.Equals(message))
		{
			ReadyToAttack = true;
		}
	}

	void Update()
	{
		if (t <= 0 && ReadyToAttack)
		{
			Weapon.gameObject.SetActive(true);
			t = Cooldown;
			ReadyToAttack = false;
		}
		else
			t -= Time.deltaTime;
	}
}