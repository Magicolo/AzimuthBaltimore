using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class ShootMotion : ComponentBehaviour
{
	public float Speed = 3f;
	[Mask(Axes.XYZ)]
	public Axes Axes = Axes.XYZ;
	public Rigidbody Rigidbody;
	public TimeComponent Time;

	public Vector3 Direction { get; set; }

	void FixedUpdate()
	{
		Rigidbody.Translate(Direction * Speed * Time.DeltaTime, Axes);
	}

	[Message(GameMessages.OnShot)]
	void OnShot(Vector3 direction)
	{
		Direction = direction;
	}
}