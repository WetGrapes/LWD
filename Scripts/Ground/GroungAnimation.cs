using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Sprites;

public class GroungAnimation : MonoBehaviour {
	
	SpriteRenderer Renderer;
	GroundAnimator Animator;
	ParticleSystem Particle;
	public Sprite[] Set = new Sprite[13];
	float MaxSpeed = 3f, MinSpeed = 0.2f;
	public int NowSprite;
	public float Multi, TimeToDead,EndDisappearance;


	void Start () {
		Renderer = GetComponent<SpriteRenderer> ();
		Animator = GameObject.Find("GroundAnimator").GetComponent<GroundAnimator> ();
		Particle = GetComponent<ParticleSystem> ();
		StartCoroutine(ChangeView ());
	}
	IEnumerator ChangeView()
	{
		NowSprite = Random.Range (0, Animator.Sets [Animator.NowSet].Set.Length);
		MaxSpeed = 0.01f * Animator.MaxFactor;
		MinSpeed = 0.01f * Animator.MinFactor;
		Renderer.sprite = Animator.Sets [Animator.NowSet].Set [NowSprite];
		yield return new WaitForSeconds (Random.Range (MinSpeed, MaxSpeed));
		StartCoroutine (ChangeView ());
		yield break;
	}

	public void Deleting()
	{
		Particle.Play ();
		StartCoroutine (ImageDesappearance());
		Destroy (gameObject, TimeToDead-EndDisappearance+0.1f);
	}

	IEnumerator ImageDesappearance()
	{
		float MinusA = (float)Renderer.color.a / Multi;
		for (int i = 0; i < Multi; i++) {
			yield return new WaitForSeconds ((TimeToDead - EndDisappearance) / Multi);
			Renderer.color = new Color (Renderer.color.r, Renderer.color.g, Renderer.color.b, Renderer.color.a - MinusA);
		}
		yield break;
	}

}
