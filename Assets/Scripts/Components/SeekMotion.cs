using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class SeekMotion : ComponentBehaviour
{
	[Mask(Axes.XYZ)]
	public Axes Axes = Axes.XYZ;
	public Vector3 Speed = new Vector3(5f, 5f, 5f);
	public Vector3 Offset;
	public float SlowDistance = 3f;
	public float StopDistance = 1f;
	public EntityMessage OnSlowing;
	public EntityMessage OnStopped;
	public TargetBase Target;
	public TimeComponent Time;
	public Transform Transform;

	bool isSlowing;
	bool isStopped;

	void FixedUpdate()
	{
		if (!Target.HasTarget)
			return;

		var position = Transform.position;
		var target = Target.Target + Offset;
		var direction = Vector3.zero.SetValues(target - position, Axes);
		float distance = direction.magnitude;
		float modifier = Mathf.Clamp01((distance - StopDistance) / (SlowDistance - StopDistance));
		var speed = Speed * modifier * Time.FixedDeltaTime;

		Transform.Translate(direction.normalized.Mult(speed), Axes);

		// Messages
		if (!isSlowing && modifier < 1f)
		{
			isSlowing = true;
			Entity.SendMessage(OnSlowing);
		}
		else if (modifier >= 1f)
			isStopped = false;

		if (!isStopped && modifier <= 0f)
		{
			isStopped = true;
			Entity.SendMessage(OnStopped);
		}
		else if (modifier > 0f)
			isStopped = false;
	}
}