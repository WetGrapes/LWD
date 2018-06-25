using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float maxSpeed  = 5f;

	public Transform groundCheck;
	public LayerMask whatIsGround;

	private Rigidbody2D rb2d;
	private bool isGrounded = false;
	private float jumpForce = 25f;
	private float groundRadius = 0.75f;

	public bool up;
	public bool left;
	public bool right;
	public bool r_corner;
	public bool l_corner;
	public float move;

	void Start () {
		 rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	

	void FixedUpdate () {
		 
		 Side ();

		 isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); 
		 
		 if(isGrounded)  rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
	}

	void Update (){
	   	 
		 Jump ();
	}

	void Side(){

		if (!right && left) {
			move = -1;
			Debug.Log (move);
		} else if (right && !left) {
			move = 1;
			Debug.Log (move);
		} else {
			move = Input.GetAxis ("Horizontal");
		}
	}

	void Jump() {
		
		if (isGrounded && up) {
			rb2d.AddForce (new Vector2 (0, jumpForce)); 			
		} else if (isGrounded && l_corner) {
			rb2d.AddForce (new Vector2 (-jumpForce / 2, jumpForce));	
		} else if (isGrounded && r_corner) {
			rb2d.AddForce (new Vector2 (jumpForce / 2, jumpForce));	
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			rb2d.AddForce (new Vector2 (0, jumpForce));			
		}
	}
}
