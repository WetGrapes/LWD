﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeltingBotton : MonoBehaviour {

	public float Puls, Speed;
	float NowPuls;
	float plusPuls ;
	int revert = 1;

	void Start () {

		NowPuls = -Puls;
		transform.localScale = new Vector3 (transform.localScale.x+NowPuls, transform.localScale.x+NowPuls, 1f);
	}

	void Update()
	{

		if (NowPuls < Puls) {
			plusPuls = Time.deltaTime * Speed ;
			transform.localScale += new Vector3 ((plusPuls * revert), (plusPuls * revert), 0f);
			NowPuls += plusPuls;
			Debug.Log (NowPuls);
		} else {
			NowPuls *= -1;
			revert *= -1;
			Debug.Log ("revert");
		}
	}
}
