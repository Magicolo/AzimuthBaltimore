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
	
	void Update()
	{
		if(LookAt.HasTarget)
		{
			var direction = LookAt.Target - Transform.position;
			direction = direction.SetValues(0, Axes.Y);
				
			Quaternion targetRotation = Quaternion.LookRotation(direction);
			Transform.localRotation = Quaternion.Lerp(Transform.localRotation, targetRotation, Time.DeltaTime);
		}
	}
}