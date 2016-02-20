using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

[Flags]
public enum DamageSources
{
	Player = 1 << 0,
	Enemy = 1 << 1,
}

[Flags]
public enum DamageTypes
{
	Particle = 1 << 0,
	Laser = 1 << 1,
}

[Serializable]
public struct DamageData
{
	public DamageSources Sources;
	public DamageTypes Types;
	public float Damage;
}
