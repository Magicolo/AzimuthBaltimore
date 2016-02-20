using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class FollowTargetSteering : SteeringBehaviorBase
{
	public TargetBase Target;

	public override Vector3 GetMotionAddition(Rigidbody rigidbody)
	{
		if (!Target.HasTarget)
			return Vector3.zero;

		var position = rigidbody.position;
		var target = Target.Target;

		return (target - position).normalized;
	}
}