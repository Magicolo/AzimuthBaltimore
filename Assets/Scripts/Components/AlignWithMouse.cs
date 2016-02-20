using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class AlignWithMouse : ComponentBehaviour
{
	public Vector3 Offset;

	[Inject("Main")]
	readonly Camera mainCamera = null;

	void Update()
	{
		var direction = Input.mousePosition - mainCamera.WorldToScreenPoint(CachedTransform.position);
		direction.z = direction.y;
		direction.y = 0f;

		CachedTransform.eulerAngles = Quaternion.LookRotation(direction).eulerAngles + Offset;
	}
}