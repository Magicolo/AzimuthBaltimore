using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class ForwardMotion : ComponentBehaviour
{
	public float Speed = 3f;
	[Mask(Axes.XYZ)]
	public Axes Axes = Axes.XYZ;
	public Rigidbody Rigidbody;
	public TimeComponent Time;

	void FixedUpdate()
	{
		Rigidbody.Translate(CachedTransform.forward * Speed * Time.DeltaTime, Axes);
	}
}