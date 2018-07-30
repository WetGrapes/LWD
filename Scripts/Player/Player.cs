using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[Space]
	public float Speed;
	public int DoubleJump;

	[System.NonSerialized] public bool Jump;
	[System.NonSerialized] public bool Left;
	[System.NonSerialized] public bool Right;
	[System.NonSerialized] public bool UpLeft;
	[System.NonSerialized] public bool UpRight;
	[System.NonSerialized] public bool Central;

	[Space]
	public bool Grounded;
	public int Force;
	[Space]
	public LayerMask WhatIsGround;
	public Transform GroundCheck;
	public float GroundRadius;
	[Space]
	private Rigidbody2D BodyPhysic;
	private Transform ObjectTransform;
	private Trajectory Way;
	public GameObject Count;
	Counters CountManager;
	[Space]

	public float jumperTime;
	public float jumperUp;
	public float jumperScaler;
	[Space]

	public bool PlayParticle;
	public ParticleSystem Particle;
	float ParticleTimer;
	//public Color[] ParticleColors;
	//GroundAnimator Animator;


	void Start () {
		BodyPhysic = gameObject.GetComponent<Rigidbody2D> ();
		Way = gameObject.GetComponent<Trajectory> ();
		CountManager = Count.GetComponent<Counters> ();
		//Animator = GameObject.Find("GroundAnimator").GetComponent<GroundAnimator> ();
		StartCoroutine (Jumper ());
		Debug.Log (LayerMask.LayerToName (8));
	}

	IEnumerator Jumper()
	{ 
		float scaler = 0;
		yield return new WaitForSeconds (jumperTime);
		if (Grounded) {
			scaler = jumperScaler;
			BodyPhysic.AddRelativeForce (transform.up * Force / jumperUp);
		}
		transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y - scaler, transform.localScale.z);
		yield return new WaitForSeconds (jumperTime);
		transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y + scaler, transform.localScale.z);
		StartCoroutine (Jumper ());
		yield break;
	}

	void FixedUpdate ()
	{
		if (!Grounded) {
			if (Physics2D.OverlapCircle (GroundCheck.position, GroundRadius, WhatIsGround))
				PlayParticle = true;
			ParticleTimer += Time.fixedDeltaTime;
		} else {

			ParticleTimer = 0f;
		}
			
		if (PlayParticle && ParticleTimer>=0.5f){//&& ParticleTimer>=1f) {
			
			/*int x = Mathf.FloorToInt (transform.position.x);
			int y = Mathf.FloorToInt (transform.position.y - 0.5f);
			GameObject ob = Physics2D.OverlapPoint (new Vector2 (GroundCheck.position.x, GroundCheck.position.y - 0.5f),
				                WhatIsGround).gameObject;
			texture = ob.GetComponent<SpriteRenderer> ().sprite.texture;
			Vector2 pixelUV = new Vector2 (ob.transform.position.x, ob.transform.position.y);
			pixelUV.x *= texture.width;
			pixelUV.y *= texture.height;

			Color color = texture.GetPixel 
				(Mathf.FloorToInt (pixelUV.x), Mathf.FloorToInt (pixelUV.y * ob.GetComponent<GroungAnimation>().NowSprite));

			var main = Particle.main;
			main.startColor = color;*/

			//var main = Particle.main;
			//main.startColor = ParticleColors[Animator.NowSet];
		
			Particle.Play ();
			PlayParticle = false;
			ParticleTimer = 0f;
		}

		Grounded = Physics2D.OverlapCircle (GroundCheck.position, GroundRadius, WhatIsGround);

		
		if (Left && Grounded) {
			StartCoroutine (MoveToSide (-1,1));
		} else if (Right && Grounded) {
			StartCoroutine (MoveToSide (1,1));
		} 
		if (Central) {
			if (Physics2D.OverlapPoint 
				(new Vector2 (transform.position.x, transform.position.y - 1), WhatIsGround) &&
				CountManager.blbCounter>0) {
				Destroy (Physics2D.OverlapPoint 
					(new Vector2 (transform.position.x, transform.position.y - 1),
					WhatIsGround).gameObject, 0.2f);
				CountManager.blbCounter--;
			}
			Central = false;
		}
	} 

	void Update () {
		if (Jump && Grounded) {

			DoubleJump = 2;
			Debug.Log ("Jump");
			Jump = false;

		} else if (UpLeft && Grounded) {
			if (UpFree()) {
				StartCoroutine (Move (1 + DoubleJump));
				UpLeft = false;
				//Debug.Log ("LJump");
			} else 
				BodyPhysic.AddRelativeForce (transform.up * Force);
			
		} else if (UpRight && Grounded) {
			if (UpFree()) {
				StartCoroutine (Move (0 + DoubleJump));
				UpRight = false;
				//Debug.Log ("RJump");
			} else 
				BodyPhysic.AddRelativeForce (transform.up * Force);
			//BodyPhysic.AddRelativeForce (ObjectTransform.transform.up * Force);
		} /*else if (UpLeft && Grounded) {
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.up * Force);
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.right * -Force);
		} else if (UpRight && Grounded) {
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.up * Force);
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.right * Force);

		} */

	}

	IEnumerator Move(int j) {
		if (!Physics2D.OverlapPoint
		(new Vector2 (GroundCheck.position.x + Way.Datas [j].FinalX, GroundCheck.position.y + Way.Datas [j].FinalY),
			   WhatIsGround)) {
			BodyPhysic.simulated = false;
			for (int i = 0; i < Way.Datas [j].Steps; i++) {
				//Debug.Log ("InFor");
				yield return new WaitForSeconds (Time.deltaTime * 0.8f);
				transform.position = new Vector3 (transform.position.x + Way.Datas [j].XPoint [i], 
					transform.position.y + Way.Datas [j].YPoint [i], 
					transform.position.z);
			}
			BodyPhysic.simulated = true;
		} else 
			BodyPhysic.AddRelativeForce (transform.up * Force);
		DoubleJump = 0;
		yield break;
	}

	bool UpFree(){
		return 	(!Physics2D.OverlapPoint
					(new Vector2 (GroundCheck.position.x, GroundCheck.position.y + 1),
					WhatIsGround) &&
				!Physics2D.OverlapPoint
					(new Vector2 (GroundCheck.position.x, GroundCheck.position.y + DoubleJump),
					WhatIsGround));
	}
    
	IEnumerator MoveToSide(int x, float time = 0.45f, int step = 5) {
		
		if(!Physics2D.OverlapPoint(new Vector2(transform.position.x+x, transform.position.y)) || 
			Physics2D.OverlapPoint(new Vector2(transform.position.x+x, transform.position.y), 10 )) {
			
			if (x > 0) {
				Right = false;
			} else Left = false; 

			for(int i=0; i<step; i++) {
				yield return new WaitForSeconds (Time.deltaTime * time);
				transform.position += new Vector3 (x * 0.20f,0,0);
			}
				

			yield return new WaitForSeconds (Time.deltaTime * time);
			yield break;
			}
	}

}