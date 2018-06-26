using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextToCamera : MonoBehaviour {

	CameraManager Cam;

	void Start () {
		Cam = GameObject.Find ("Main Camera").GetComponent<CameraManager> ();
		WithStart ();
	}

	protected void StateToCamera(int State)
	{
		Cam.nowTarget = State;
	}
	protected virtual void WithStart(){}
}
