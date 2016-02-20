using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

[MessageEnum]
public enum GameMessages
{
	// Actions
	Damage = -1000,
	Kill,
	Shoot,

	// Reactions
	OnDamaged = 1000,
	OnKilled,
	OnShot,
	OnTargetSeen
}
