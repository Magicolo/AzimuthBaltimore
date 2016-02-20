using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class InputMotion : ComponentBehaviour
{
	public float Speed = 5f;
	public Players Player = Players.Player1;
	public string Horizontal = "MoveX";
	public string Vertical = "MoveY";
	public TimeComponent Time;
	public Rigidbody Rigidbody;

	Vector3 motion;

	[Inject]
	readonly IInputManager inputManager = null;

	void Update()
	{
		motion.x = inputManager.GetAxis(Player, Horizontal);
		motion.z = inputManager.GetAxis(Player, Vertical);
		motion = motion.normalized * Speed;
	}

	void FixedUpdate()
	{
		Rigidbody.Translate(motion * Time.FixedDeltaTime, Axes.XZ);
	}
}