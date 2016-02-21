using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class DirectionSteering : SteeringBehaviorBase
{
	public Vector3 Direction;

	public override Vector3 GetMotionAddition(Rigidbody rigidbody)
	{
		return Direction;
	}
}