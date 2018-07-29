using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBonus : Bonuses {

	protected override void ActBonus()
	{
		Manager.GetComponent<Counters> ().blbCounter++;
	}
}
