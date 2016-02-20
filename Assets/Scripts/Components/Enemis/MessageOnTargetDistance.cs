using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class MessageOnTargetDistance : ComponentBehaviour
{
	public EntityBehaviour Source;
	public EntityMessage Message;
	public TargetBase Target;

	public float Distance;
	public Operator OperatorCheck;
	public enum Operator { LessThen, MoreThen};

	void Update()
	{
		if (!Target.HasTarget) return;

		float distance = Vector3.Distance(Source.transform.position, Target.Target);
		switch (OperatorCheck)
		{
			case Operator.LessThen:
				if (distance <= Distance)
					Entity.SendMessage(Message);
				break;
			case Operator.MoreThen:
				if (distance >= Distance)
					Entity.SendMessage(Message);
				break;
		}
	}
}