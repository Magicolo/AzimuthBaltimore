using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class PatrolSteeringBehavior : SteeringBehaviorBase
{
	public Waypoint TargetWayPoint;
	public NavMeshAgent Agent;
	[Min]
	public float ChangeTargetCloseness = 0.1f;

	void Start()
	{
		base.Start();
		Agent.SetDestination(TargetWayPoint.transform.position);
		Agent.updatePosition = false;
		Agent.updateRotation = false;
	}

	public override Vector3 GetMotionAddition(Rigidbody rigidbody)
	{
		Vector3 targetP = TargetWayPoint.transform.position.SetValues(0, Axes.Y);
		Vector3 currentP = rigidbody.position.SetValues(0, Axes.Y);
		
		Debug.DrawLine(transform.position, targetP + (targetP - currentP).normalized, Color.red);

		if (Vector3.Distance(targetP, currentP) < ChangeTargetCloseness)
		{
			TargetWayPoint = TargetWayPoint.NextWayPoint;
		}
		Agent.SetDestination(targetP);
		targetP = Agent.steeringTarget.SetValues(0, Axes.Y);
		
		Debug.DrawLine(transform.position, targetP + (targetP - currentP).normalized, Color.green);

		//PDebug.Log(targetP , (targetP - currentP).normalized);
		return (targetP - currentP).normalized;
	}
}
