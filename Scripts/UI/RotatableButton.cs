using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableButton : MonoBehaviour {
	public float Angle, Speed;
	float RotateAngle;
	float plusSpeed ;
	int revert = 1;

	void Start () {
		
		RotateAngle = -Angle;
		transform.Rotate (0f, 0f, RotateAngle);
	}

	void Update()
	{

		if (RotateAngle < Angle) {
			plusSpeed = Time.deltaTime * Speed ;
			transform.Rotate (0f, 0f, plusSpeed * revert);
			RotateAngle += plusSpeed;
			Debug.Log (RotateAngle);
		} else {
			RotateAngle *= -1;
			revert *= -1;
			Debug.Log ("revert");
		}
	}

}
