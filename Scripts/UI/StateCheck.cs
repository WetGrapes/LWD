using System.Collections;
using System.Collections.Generic;
using System;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class StateCheck : INeedCam {
	
	[SerializeField] int State = 0;
	[SerializeField] string[] ComponentNames = new string[0];
	[SerializeField] bool OnThisState = true;

	protected override void WithStartAnother()
	{
		
		StartCoroutine (Checker (State));
	}

	IEnumerator Checker(int State)
	{

		for (int i = 0; i < ComponentNames.Length; i++) 
			(gameObject.GetComponent (ComponentNames[i]) as Behaviour).enabled = Check (State);
		
		yield return new WaitForSeconds (0.2f);
		StartCoroutine (Checker (State));
	}
	bool Check(int State)
	{
		FoundCam ();
		return Cam.nowTarget == State ? OnThisState : !OnThisState;
	}
}
