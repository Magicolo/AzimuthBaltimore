using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class FollowTargetSteering : SteeringBehaviorBase
{
	public TargetBase Target;
	public NavMeshAgent Agent;

	public override Vector3 GetMotionAddition(Rigidbody rigidbody)
	{
		if (!Target.HasTarget)
			return Vector3.zero;

		Agent.SetDestination(Target.Target);

		var position = rigidbody.position;
		var target = Agent.steeringTarget.SetValues(0, Axes.Y);

		Debug.DrawLine(position, Target.Target + (Target.Target - position).normalized, Color.green);
		Debug.DrawLine(position, target + (target - position).normalized, Color.red);

		return (target - position).normalized;
	}
}