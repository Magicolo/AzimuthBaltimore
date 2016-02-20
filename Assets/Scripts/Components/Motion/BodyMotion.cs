using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class BodyMotion : ComponentBehaviour
{
	public NavMeshAgent Agent;
	public TimeComponent Time;
	public Rigidbody Rigidbody;
	[Mask(Axes.XYZ)]
	public Axes Axes = Axes.XZ;

	public bool lookAtDirection;

	public float Speed = 5;



	void FixedUpdate()
	{
		Vector3 motion = gatherMotion().SetValues(0,Axes.Y);
		if (lookAtDirection)
			Rigidbody.transform.LookAt(Rigidbody.transform.position + motion,Vector3.up);

		if (Agent)
			Agent.Move(motion * Time.FixedDeltaTime);
		Rigidbody.Translate(motion * Time.FixedDeltaTime, Axes);
	}

	private Vector3 gatherMotion()
	{
		Vector3 motion = gatherSterringBehavior();
		float speedModifier = gatherSpeedModifiers();
		return motion * speedModifier;
	}

	private float gatherSpeedModifiers()
	{
		float speed = Speed;
		var modifs = GetComponentsInChildren<MotionSpeedModifier>(false);
		foreach (var speedModif in modifs)
		{
			speed = speedModif.ModifieSpeed(speed);
		}
		return speed;
	}

	private Vector3 gatherSterringBehavior()
	{
		Vector3 motion = Vector3.zero;

		var steerings = GetComponentsInChildren<SteeringBehaviorBase>(false);
		for (int i = 0; i < steerings.Length; i++)
		{
			var steering = steerings[i];
			motion += steering.GetMotionAddition(Rigidbody);
		}
		
		return motion.normalized;
	}
}