using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public abstract class SteeringBehaviorBase : ComponentBehaviour
{
	public abstract Vector3 GetMotionAddition(TimeComponent time, Rigidbody rigidbody);
}