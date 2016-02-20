using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class DebugLogOnMessage : ComponentBehaviour, IMessageable
{
	public MessageEnum Message;

	public void OnMessage<TId>(TId message)
	{
		if(Message.Equals(message))
		{
			PDebug.Log(Message +" recieved on " + transform.name);
		}
	}
}