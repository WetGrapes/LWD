using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTop : MonoBehaviour {
	protected GameObject Interface, PointsDisplay, PlayerOb;
	protected Generation GenerationManager;
	protected CameraManager Cam;
	void Start()
	{
		GenerationManager = GameObject.Find ("Generator").GetComponent<Generation> ();
		Cam =  GameObject.Find ("Main Camera").GetComponent<CameraManager> ();
		PlayerOb = GameObject.Find ("Player");
		Interface = GameObject.Find ("Interface");
		PointsDisplay = GameObject.Find ("PointsDisplay");
	}

	protected virtual void MoveCameraAndState () {
		
	}
	void OnMouseDown()
	{
		StartCoroutine (Restart ());
	}
	IEnumerator Restart()
	{
		Cam.nowTarget = 5;
		GenerationManager.GenDone = false;
		StartCoroutine(GenerationManager.AllStackRemove ());
		yield return new WaitForSeconds (0.4f);
		Cam.nowTarget = 5;
		PlayerOb.transform.position = new Vector3 (0f, 6.5f, 0f);
		Interface.GetComponent<InterfaceMove> ().LowestPoint = 0;
		Interface.transform.localPosition = new Vector3 (0f, 0f, -10f);
		PointsDisplay.transform.position = new Vector3 (-9.5f, -1f, -10f);
		Cam.gameObject.transform.position = new Vector3 (-9.5f, -1f, -40f);
		yield return new WaitForSeconds (0.1f);
		GenerationManager.ToStart ();
		yield return new WaitForSeconds (0.2f);
		MoveCameraAndState ();
		yield break;
	}

}
