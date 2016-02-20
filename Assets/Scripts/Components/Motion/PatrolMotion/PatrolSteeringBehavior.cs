using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class PatrolSteeringBehavior : SteeringBehaviorBase
{
	public Waypoint TargetWayPoint;
	[Min]
	public float ChangeTargetCloseness = 0.1f;

	public override Vector3 GetMotionAddition(TimeComponent time, Rigidbody rigidbody)
	{
		Vector3 targetP = TargetWayPoint.transform.position;
		Vector3 currentP = rigidbody.position;

		if (Vector3.Distance(targetP, currentP) < ChangeTargetCloseness)
			TargetWayPoint = TargetWayPoint.NextWayPoint;
		
		targetP = TargetWayPoint.transform.position;

		return (targetP - currentP).normalized;
	}
}
