using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	[SerializeField] Transform[] target = new Transform[0];
	[Range(0,3)]public int nowTarget;

	public float damping = 1, lookAheadFactor = 3, lookAheadReturnSpeed = 0.5f, lookAheadMoveThreshold = 0;
	float offsetZ;

	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;

	void Start () {
		lastTargetPosition = target[nowTarget].position;
		offsetZ = (transform.position - target[nowTarget].position).z;

	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			
			float yMoveDelta = (target[nowTarget].position - lastTargetPosition).y;
			bool updateLookAheadTarget = Mathf.Abs (yMoveDelta) > lookAheadMoveThreshold;

			if (updateLookAheadTarget)
				lookAheadPos = lookAheadFactor * Vector3.up* Mathf.Sign (yMoveDelta);
			else
				lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);

			Vector3 aheadTargetPos = target[nowTarget].position + lookAheadPos + Vector3.forward * offsetZ;
			Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
			transform.position = newPos;
			lastTargetPosition = transform.position;

		} else 
			Debug.Log ("CameraManage Target not found");
		
		}
}
