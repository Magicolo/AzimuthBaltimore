using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class SeekTarget : ComponentBehaviour
{
	public Vector3 Speed = new Vector3(5f, 5f, 5f);
	public Vector3 Offset;
	[Mask(Axes.XYZ)]
	public Axes Axes = Axes.XYZ;
	public TargetBase Target;
	public TimeComponent Time;
	public Transform Transform;

	void FixedUpdate()
	{
		if (!Target.HasTarget)
			return;

		var position = Transform.position;
		var target = Target.Target;

		if ((Axes & Axes.X) != 0)
			position.x = Mathf.Lerp(position.x, target.x + Offset.x, Speed.x * Time.FixedDeltaTime);
		if ((Axes & Axes.Y) != 0)
			position.y = Mathf.Lerp(position.y, target.y + Offset.y, Speed.y * Time.FixedDeltaTime);
		if ((Axes & Axes.Z) != 0)
			position.z = Mathf.Lerp(position.z, target.z + Offset.z, Speed.z * Time.FixedDeltaTime);

		Transform.position = position;
	}
}