using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class MultiplicatifSpeedModifier : MotionSpeedModifier
{

	public float Factor = 1;

	public override float ModifieSpeed(float speed)
	{
		return speed * Factor; 
	}
}