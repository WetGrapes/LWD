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

	public float jumperTime, jumperUp, jumperScaler;





	void Start () {
		BodyPhysic = gameObject.GetComponent<Rigidbody2D> ();
		Way = gameObject.GetComponent<Trajectory> ();
		CountManager = Count.GetComponent<Counters> ();
		StartCoroutine (Jumper ());
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
	}

	void FixedUpdate ()
	{

		Grounded = Physics2D.OverlapCircle (GroundCheck.position, GroundRadius, WhatIsGround);

		if (Left) {
			BodyPhysic.velocity = new Vector2 (-Speed, BodyPhysic.velocity.y);
		} else if (Right) {
			BodyPhysic.velocity = new Vector2 (Speed, BodyPhysic.velocity.y);
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
			Jump = false;
			Debug.Log ("Jump");

		} else if (UpLeft && Grounded) {
			if (UpFree()) {
				StartCoroutine (Move (1 + DoubleJump));
				UpLeft = false;
				Debug.Log ("LJump");
			} else 
				BodyPhysic.AddRelativeForce (transform.up * Force);
			
		} else if (UpRight && Grounded) {
			if (UpFree()) {
				StartCoroutine (Move (0 + DoubleJump));
				UpRight = false;
				Debug.Log ("RJump");
			} else 
				BodyPhysic.AddRelativeForce (transform.up * Force);
			
		} 

	}

	IEnumerator Move(int j) {
		if (!Physics2D.OverlapPoint
		(new Vector2 (GroundCheck.position.x + Way.Datas [j].FinalX, GroundCheck.position.y + Way.Datas [j].FinalY),
			   WhatIsGround)) {
			BodyPhysic.simulated = false;
			for (int i = 0; i < Way.Datas [j].Steps; i++) {
				Debug.Log ("InFor");
				yield return new WaitForSeconds (Time.deltaTime * 0.8f);
				transform.position = new Vector3 (transform.position.x + Way.Datas [j].XPoint [i], 
					transform.position.y + Way.Datas [j].YPoint [i], 
					transform.position.z);
			}
			BodyPhysic.simulated = true;
		} else 
			BodyPhysic.AddRelativeForce (transform.up * Force);
		DoubleJump = 0;
	}

	bool UpFree(){
		return 	(!Physics2D.OverlapPoint
					(new Vector2 (GroundCheck.position.x, GroundCheck.position.y + 1),
					WhatIsGround) &&
				!Physics2D.OverlapPoint
					(new Vector2 (GroundCheck.position.x, GroundCheck.position.y + DoubleJump),
					WhatIsGround));
	}
}