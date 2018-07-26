using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBonus : Bonuses {

	protected override void ActBonus()
	{
		Manager.GetComponent<TimeManager>().TimeCount += 10;
	}
}
