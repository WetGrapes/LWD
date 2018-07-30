using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
public class Bonuses : MonoBehaviour {
	public GameObject Player;
	public GameObject Manager;
//	public ParticleSystem Particle;
//	public SpriteRenderer Renderer;

	protected bool Tink = true;

	void Update () {
		if (Near()) {
			if (Tink) {
				ActBonus ();
//				Particle.Play ();
//				if (Renderer)
//					StartCoroutine ();
				Destroy (gameObject, 0.5f);
			}
			Tink = false;
		}
	}
	bool Near () {
		return 
			(Mathf.Abs (Player.transform.position.x - transform.position.x) < 0.5f &&
			Mathf.Abs (Player.transform.position.y - transform.position.y) < 0.5f);
	}

	//IEnumerator 

	protected virtual void ActBonus()
	{
	}
}
