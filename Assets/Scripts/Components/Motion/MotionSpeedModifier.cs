using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public abstract class MotionSpeedModifier : ComponentBehaviour
{
	public abstract float ModifieSpeed(float speed);
}