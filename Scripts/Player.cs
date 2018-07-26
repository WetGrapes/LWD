using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
<<<<<<< HEAD
	[Space]
	public float Speed;
	public int DoubleJump;
=======

	public float Speed;
>>>>>>> 524c57a7f0c6e1a324a226111bceb7f39f887113
	[System.NonSerialized] public bool Jump;
	[System.NonSerialized] public bool Left;
	[System.NonSerialized] public bool Right;
	[System.NonSerialized] public bool UpLeft;
	[System.NonSerialized] public bool UpRight;
	[System.NonSerialized] public bool Central;
<<<<<<< HEAD
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
=======
	public bool Grounded;
	public int Force;

	public LayerMask WhatIsGround;
	public Transform GroundCheck;
	public float GroundRadius;

	private Rigidbody2D BodyPhysic;
	private Transform ObjectTransform;
>>>>>>> 524c57a7f0c6e1a324a226111bceb7f39f887113





	void Start () {
		BodyPhysic = gameObject.GetComponent<Rigidbody2D> ();
		Way = gameObject.GetComponent<Trajectory> ();
		CountManager = Count.GetComponent<Counters> ();
		StartCoroutine (Jumper ());
	}


<<<<<<< HEAD
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
=======
	void Start () {
		BodyPhysic = gameObject.GetComponent<Rigidbody2D> ();
		ObjectTransform = gameObject.GetComponent<Transform> ();
>>>>>>> 524c57a7f0c6e1a324a226111bceb7f39f887113
	}

	void FixedUpdate ()
	{
<<<<<<< HEAD
=======
		
		Grounded = Physics2D.OverlapCircle (GroundCheck.position, GroundRadius, WhatIsGround);

>>>>>>> 524c57a7f0c6e1a324a226111bceb7f39f887113

		Grounded = Physics2D.OverlapCircle (GroundCheck.position, GroundRadius, WhatIsGround);

<<<<<<< HEAD
		if (Left) {
			BodyPhysic.velocity = new Vector2 (-Speed, BodyPhysic.velocity.y);
		} else if (Right) {
=======
		if (Left && Grounded) {
			BodyPhysic.velocity = new Vector2 (-Speed, BodyPhysic.velocity.y);
		} else if (Right && Grounded) {
>>>>>>> 524c57a7f0c6e1a324a226111bceb7f39f887113
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
<<<<<<< HEAD
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
			
=======
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.up * Force);
		} else if (UpLeft && Grounded) {
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.up * Force);
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.right * -Force);
		} else if (UpRight && Grounded) {
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.up * Force);
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.right * Force);
>>>>>>> 524c57a7f0c6e1a324a226111bceb7f39f887113
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