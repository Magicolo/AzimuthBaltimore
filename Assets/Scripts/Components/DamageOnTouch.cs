using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class DamageOnTouch : ComponentBehaviour
{
	public DamageData Damage;
	public EntityMessage Message;

	void OnTriggerEnter(Collider collision)
	{
		var entity = collision.GetEntity();

		if (entity != null)
			entity.SendMessage(Message, Damage);
	}
}