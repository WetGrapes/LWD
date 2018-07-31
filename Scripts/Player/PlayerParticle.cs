using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour {
	public bool PlayParticle;
	public ParticleSystem Particle;
	public float ParticleTimer, FlightTime;
	public Color[] ParticleColors;
	GroundAnimator Animator;

	public void SystemStart()
	{
		if (PlayParticle && ParticleTimer >= FlightTime){

			//SetParticleColor(TakeAPixel ());
			Particle.Play ();
			PlayParticle = false;
			ParticleTimer = 0f;
		}
		PlayParticle = false;
	}
	public void IfNotGrounded(bool grounded, bool overlap)
	{

		if (!grounded) {
			if (overlap)
				PlayParticle = true;
			ParticleTimer += Time.fixedDeltaTime;
		} else {
			ParticleTimer = 0f;
		}
	}

	Color TakeAPixel()
	{
		GameObject ob = Physics2D.OverlapPoint (new Vector2 (transform.position.x, transform.position.y - 1f)).gameObject;
		Texture2D texture = ob.GetComponent<SpriteRenderer> ().sprite.texture;
		Vector2 pixelUV = new Vector2 (ob.transform.position.x, ob.transform.position.y);
		pixelUV.x *= texture.width;
		pixelUV.y *= texture.height;

		Color color = texture.GetPixel 
			(Mathf.FloorToInt (pixelUV.x), Mathf.FloorToInt (pixelUV.y * ob.GetComponent<GroungAnimation>().NowSprite));

		return color;
	}

	Color PickAColor()
	{
		return ParticleColors[Animator.NowSet];
	}

	void SetParticleColor(Color color)
	{
		var main = Particle.main;
		main.startColor = color;
	}

}
