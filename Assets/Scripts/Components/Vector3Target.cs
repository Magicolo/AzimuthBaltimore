using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class Vector3Target : TargetBase
{
	public bool hasTarget;
	public Vector3 TargetLocation;

	public override bool HasTarget { get { return hasTarget; } }

	public override Vector3 Target{ get{ return TargetLocation; } }
}