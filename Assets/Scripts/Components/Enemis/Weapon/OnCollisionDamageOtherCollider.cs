using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class OnCollisionDamageOtherCollider : ComponentBehaviour
{

	public EntityBehaviour WeaponRoot;
	public EntityGroups Attackable;
	public DamageData DamageData;

	void OnTriggerEnter(Collider other)
	{

		other.GetEntity().SendMessage(GameMessages.OnDamaged, DamageData);
	}
}