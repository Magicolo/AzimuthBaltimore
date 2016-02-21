using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class LookAtTarget : ComponentBehaviour
{
	public TargetBase LookAt;
	public Transform Transform;
	public TimeComponent Time;
	public Axes Axes;

	
	void Update()
	{
		if(LookAt.HasTarget)
		{
			var direction = LookAt.Target - Transform.position;
			//if(Axes. & Axes.X > 0)
			Quaternion targetRotation = Quaternion.LookRotation(direction);
			Transform.localRotation = Quaternion.Lerp(Transform.localRotation, targetRotation, Time.DeltaTime);
		}
	}
}