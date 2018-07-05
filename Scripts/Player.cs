using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float Speed;
	[System.NonSerialized] public bool Jump;
	[System.NonSerialized] public bool Left;
	[System.NonSerialized] public bool Right;
	[System.NonSerialized] public bool UpLeft;
	[System.NonSerialized] public bool UpRight;
	[System.NonSerialized] public bool Central;
	public bool Grounded;
	public int Force;

	public LayerMask WhatIsGround;
	public Transform GroundCheck;
	public float GroundRadius;

	private Rigidbody2D BodyPhysic;
	private Transform ObjectTransform;







	void Start () {
		BodyPhysic = gameObject.GetComponent<Rigidbody2D> ();
		ObjectTransform = gameObject.GetComponent<Transform> ();
	}
	

	void FixedUpdate ()
	{
		
		Grounded = Physics2D.OverlapCircle (GroundCheck.position, GroundRadius, WhatIsGround);



		if (Left && Grounded) {
			BodyPhysic.velocity = new Vector2 (-Speed, BodyPhysic.velocity.y);
		} else if (Right && Grounded) {
			BodyPhysic.velocity = new Vector2 (Speed, BodyPhysic.velocity.y);
		} 
	

   } 

	void Update () {


		if (Jump && Grounded) {
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.up * Force);
		} else if (UpLeft && Grounded) {
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.up * Force);
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.right * -Force);
		} else if (UpRight && Grounded) {
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.up * Force);
			BodyPhysic.AddRelativeForce (ObjectTransform.transform.right * Force);
		} 
	               }
}
