using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class BodyMotion : ComponentBehaviour
{
	public TimeComponent Time;
	public Rigidbody Rigidbody;
	public Axes Axes = Axes.XZ;

	public float speed = 5;

	void FixedUpdate()
	{
		Vector3 motion = gatherMotion();
		Rigidbody.Translate(motion * Time.FixedDeltaTime, Axes);
	}

	private Vector3 gatherMotion()
	{
		Vector3 motion = gatherSterringBehavior();
		
		return motion * speed;
	}

	private Vector3 gatherSterringBehavior()
	{
		Vector3 motion = Vector3.zero;

		var steerings = GetComponents<SteeringBehaviorBase>();
		for (int i = 0; i < steerings.Length; i++)
		{
			var steering = steerings[i];
			motion += steering.GetMotionAddition(Time, Rigidbody);
		}
		
		return motion;
	}
}