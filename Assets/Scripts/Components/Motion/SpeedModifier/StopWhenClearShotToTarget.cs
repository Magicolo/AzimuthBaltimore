using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class StopWhenClearShotToTarget : MotionSpeedModifier
{
	public TargetBase Target;
	public MinMax DistanceRange;
	public Transform TransformRoot;

	public override float ModifieSpeed(float speed)
	{
		float distance = Vector3.Distance(Target.Target, TransformRoot.position);
		if (distance.IsBetween(DistanceRange))
		{
			//Debug.Log("FIRE !!");	
		return 0.001f;

		}
			
		else
			return speed;
	}
}