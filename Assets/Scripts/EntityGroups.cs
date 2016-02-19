using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Pseudo;

namespace Pseudo
{
	public partial class EntityGroups
	{
		public static readonly EntityGroups Player = new EntityGroups(0);
		public static readonly EntityGroups Enemy = new EntityGroups(1);
	}
}
