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
	public string AnimatorSpeed = "Speed";
	public string AnimatorDirection = "Direction";
	public TimeComponent Time;
	public Rigidbody Rigidbody;
	public Animator Animator;

	Vector3 motion;
	int lastDirection;

	[Inject]
	readonly IInputManager inputManager = null;

	void Update()
	{
		motion.x = inputManager.GetAxis(Player, Horizontal);
		motion.z = inputManager.GetAxis(Player, Vertical);
		motion = motion.normalized * Speed;

		float speed = motion.magnitude;
		int direction;

		if (speed <= 0.1f)
			direction = lastDirection;
		else if (Mathf.Abs(motion.x) >= Mathf.Abs(motion.z))
		{
			direction = 0;
			Animator.transform.SetLocalScale(motion.x.Sign(), Axes.X);
		}
		else
			direction = motion.z.Sign();

		Animator.SetFloat(AnimatorSpeed, speed);
		Animator.SetInteger(AnimatorDirection, direction);
		lastDirection = direction;
	}

	void FixedUpdate()
	{
		Rigidbody.Translate(motion * Time.FixedDeltaTime, Axes.XZ);
	}
}