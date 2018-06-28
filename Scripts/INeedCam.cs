using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INeedCam : UIBehaviour {

	protected CameraManager Cam;

	protected override void WithStartAnother()
	{
		FoundCam ();
	}

	protected void StateToCamera(int State)
	{ Cam.nowTarget = State;}

	protected void FoundCam()
	{
		Cam =  GameObject.Find ("Main Camera").GetComponent<CameraManager> ();
	}

}
