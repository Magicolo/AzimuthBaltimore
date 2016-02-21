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
			Quaternion targetRotation = Quaternion.LookRotation(LookAt.Target - Transform.position);
			Transform.localRotation = Quaternion.Lerp(Transform.localRotation, targetRotation, Time.DeltaTime);
		}
	}
}