using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBonus : Bonuses {

	protected override void ActBonus()
	{
		Manager.GetComponent<Counters> ().LevelSphereCounter++;
	}
}
