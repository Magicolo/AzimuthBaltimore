using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class SeekTarget : ComponentBehaviour
{
	public Vector3 Speed = new Vector3(5f, 5f, 5f);
	[Mask(Axes.XYZ)]
	public Axes Axes = Axes.XYZ;
	public TargetBase Target;
	public TimeComponent Time;
	public Transform Transform;
}