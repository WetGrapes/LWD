using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBonus : Bonuses {
	public ParticleSystem SecondParticle;
	bool InCam;
	protected override void ActBonus()
	{
		Manager.GetComponent<TimeManager>().TimeCount -= 5;
	}
	protected override void AnotherUpdate()
	{
		if (Camera.main && !InCam) {
			if ( Camera.main.transform.position.y - transform.position.y  >
				(Camera.main.orthographicSize * 2-3)*-1) 
			{
				SecondParticle.Play ();
				InCam = true;
			} else
				SecondParticle.Pause ();
		}
		/*if (InCam) {
			if (transform.position.y - Camera.main.transform.position.y <
				(Camera.main.orthographicSize * 2-3)*-1)  {
				Destroy (gameObject, 0.3f);
			}
		}*/
	}
}


///-18 - (-20) >  6*2 - 3
/// 2 > 9
