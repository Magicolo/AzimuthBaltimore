using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

public class OnCollisionDamageOtherCollider : ComponentBehaviour
{

	public EntityBehaviour WeaponRoot;
	public bool DisableWeaponRoot;
	public bool RecycleWeaponRoot;

	public EntityGroups Attackable;
	public DamageData DamageData;



	void OnTriggerEnter(Collider other)
	{
		if(other.GetEntity() != null)
		{
			other.GetEntity().SendMessage(GameMessages.OnDamaged, DamageData);
		}
		
		if (DisableWeaponRoot)
			WeaponRoot.gameObject.SetActive(false);
		if (RecycleWeaponRoot)
			WeaponRoot.Entity.Manager.RecycleEntity(WeaponRoot);
	}
}