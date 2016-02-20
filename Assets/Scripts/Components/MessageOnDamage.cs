using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class MessageOnDamage : ComponentBehaviour
{
	[EnumFlags]
	public DamageSources Sources;
	[EnumFlags]
	public DamageTypes Types;
	public EntityMessage Message;

	[Message(GameMessages.Damage)]
	void Damage(DamageData data)
	{
		if ((Sources & data.Sources) != 0 && (Types & data.Types) != 0)
			Entity.SendMessage(Message, data);
	}
}