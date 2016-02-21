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

	public override float ModifieSpeed(float speed)
	{
		
		return speed;
	}
}