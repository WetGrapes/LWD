using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBonus : Bonuses {
	public ParticleSystem SecondParticle;
	public AudioSource SecondAudio;
	bool InCam;

	protected override void ActBonus()
	{
		SecondAudio.Stop ();
		Manager.GetComponent<TimeManager>().TimeCount -= 5;
	}
	protected override void AnotherUpdate()
	{
		SecondAudio.volume = MinimalRange (2f);
		if (Camera.main && !InCam) {
			
			if ( Camera.main.transform.position.y - transform.position.y  >
				(Camera.main.orthographicSize * 2-3)*-1) 
			{
				
				SecondParticle.Play ();
				SecondAudio.Play ();
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


	float MinimalRange (float Range){
		
		float Y = (Player.transform.position.y - transform.position.y) ;
		Y = Y >= 0 ? Y : -Y;
		float X =(Player.transform.position.x - transform.position.x);
		X = X >= 0 ? X : -X;
		if (Y < Range || X < Range) {
			if(!SecondAudio.isPlaying)
			{
				SecondAudio.Play ();
				SecondAudio.time = Random.Range (0f, 2f);
			}
			return 1f - (Mathf.Lerp(X/Range,Y/Range,0.5f));

		} else
			return 0;
	}
}


///-18 - (-20) >  6*2 - 3
/// 2 > 9
/// 
///
