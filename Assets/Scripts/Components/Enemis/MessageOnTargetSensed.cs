using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class MessageOnTargetSensed : ComponentBehaviour
{
	public EntityGroups Targets;
	public float Proximity;
	public EntityMessage Message;

	void Update()
	{
		foreach (var target in Entity.Manager.Entities.Filter(Targets).ToArray())
		{
			if (Vector3.Distance(target.GetTransform().position, this.transform.position) <= Proximity)
			{
				Entity.SendMessage(Message);
			}
		}
	}
}