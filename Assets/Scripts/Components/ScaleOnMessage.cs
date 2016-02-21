using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class ScaleOnMessage : ComponentBehaviour, IMessageable
{
	[Serializable]
	public struct ScaleMessage
	{
		public Vector3 Scale;
		public Axes Axes;
		public float Speed;
		public MessageEnum Message;
	}

	public ScaleMessage[] Messages = new ScaleMessage[0];
	public Transform Target;
	public TimeComponent Time;

	Vector3 initialScale;
	Vector3 targetScale;
	float speed;
	Axes axes;

	void Awake()
	{
		initialScale = transform.localScale;
		targetScale = initialScale;
	}

	void Update()
	{
		Target.ScaleLocalTowards(targetScale, speed * Time.DeltaTime, axes);
	}

	public void OnMessage<TId>(TId message)
	{
		for (int i = 0; i < Messages.Length; i++)
		{
			var scaleMessage = Messages[i];

			if (scaleMessage.Message.Equals(message))
			{
				targetScale = scaleMessage.Scale;
				speed = scaleMessage.Speed;
				axes = scaleMessage.Axes;
			}
		}
	}
}