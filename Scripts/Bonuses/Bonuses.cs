using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
public class Bonuses : MonoBehaviour {
	public GameObject Player;
	public GameObject Manager;
	public ParticleSystem Particle;
	public SpriteRenderer Renderer;
	public AudioSource Audio;
	public float Multi, TimeToDead,EndDisappearance;
	protected bool Tink = true;

	void Start()
	{
		Audio =  gameObject.GetComponent<AudioSource> ();
		Particle = gameObject.GetComponent<ParticleSystem> ();
		Renderer = gameObject.GetComponent<SpriteRenderer> ();
		AnotherStart ();
	}
	void Update () {

		AnotherUpdate ();
		if (Near()) {
			if (Tink) {
				ActBonus ();
				if (Particle) {
					Audio.Play ();
					Particle.Play ();
					Debug.Log ("particle");
				}
				if (Renderer)
					StartCoroutine (ImageDesappearance());
				Destroy (gameObject, TimeToDead);
			}
			Tink = false;
		}
	}
	bool Near () {
		return 
			(Mathf.Abs (Player.transform.position.x - transform.position.x) < 0.5f &&
			Mathf.Abs (Player.transform.position.y - transform.position.y) < 0.5f);
	}

	IEnumerator ImageDesappearance()
	{
		float MinusA = (float) Renderer.color.a/Multi;
		for (int i = 0; i < Multi; i++) {
			yield return new WaitForSeconds ((TimeToDead-EndDisappearance) / Multi);
			Renderer.color = new Color (Renderer.color.r, Renderer.color.g, Renderer.color.b, Renderer.color.a - MinusA);
		}
		yield break;
	}

	protected virtual void ActBonus()
	{
	}
	protected virtual void AnotherUpdate()
	{
	}
	protected virtual void AnotherStart()
	{
	}
}
