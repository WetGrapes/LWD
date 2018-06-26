using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAnimator : MonoBehaviour {
	public GroundColorSet[] Sets;
	[Range(0, 6)] public int NowSet;
	[Range(1, 100)] public int MaxFactor=50, MinFactor =20;
	public void MaxFactorChange(float NewFactor)
	{
		MaxFactor = (int)(100*NewFactor);
	}
	public void MinFactorChange(float NewFactor)
	{
		MinFactor = (int)(100*NewFactor);
	}

	public void SetChange(float NewSet)
	{
		NowSet = (int)NewSet;
	}

}
