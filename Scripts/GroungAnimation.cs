using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class GroungAnimation : MonoBehaviour {
	
	SpriteRenderer Render;
	GroundAnimator Animator;

	float MaxSpeed = 3f, MinSpeed = 0.2f;

	void Start () {
		Render = GetComponent<SpriteRenderer> ();
		Animator = GameObject.Find("GroundAnimator").GetComponent<GroundAnimator> ();
		StartCoroutine(ChangeView ());
	}
	

	IEnumerator ChangeView()
	{
		MaxSpeed = 0.05f * Animator.MaxFactor;
		MinSpeed = 0.05f * Animator.MinFactor;
		Render.sprite = Animator.Sets [Animator.NowSet].Set [Random.Range (0, Animator.Sets [Animator.NowSet].Set.Length)];
		yield return new WaitForSeconds (Random.Range (MinSpeed, MaxSpeed));
		StartCoroutine (ChangeView ());
	}
}
