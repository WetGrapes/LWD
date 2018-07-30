using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumper : MonoBehaviour {
	public float jumperTime;
	public float jumperUp;
	public float jumperScaler;

	public IEnumerator Play(bool Grounded, Rigidbody2D BodyPhysic)
	{ 
		float scaler = 0;
		yield return new WaitForSeconds (jumperTime);
		if (Grounded) {
			scaler = jumperScaler;
			BodyPhysic.AddRelativeForce (transform.up * jumperUp);
		}
		transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y - scaler, transform.localScale.z);
		yield return new WaitForSeconds (jumperTime);
		transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y + scaler, transform.localScale.z);
		StartCoroutine (Play (Grounded, BodyPhysic));
		yield break;
	}
}
