using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;
	public bool jump;
	public bool left;
	public bool right;
	public bool upleft;
	public bool upright;
	public bool central;
	public bool Grounded;
	public int force;

	public LayerMask Whatisground;
	public Transform groundCheck;
	public float groundRadius;

	private Rigidbody2D rb2d;
	private Transform tf;







	void Start () {
		 rb2d = gameObject.GetComponent<Rigidbody2D> ();
		   tf = gameObject.GetComponent<Transform> ();
	}
	

	void FixedUpdate ()
	{
		
		Grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, Whatisground);



		if (left && Grounded) {
			rb2d.velocity = new Vector2 (-speed, rb2d.velocity.y);
		} else if (right && Grounded) {
			rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
		} 
	

   } 

	void Update () {

		RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, Vector2.down);
		if (hit.collider != null) {

			Debug.Log (hit.distance);
		
		}

		
		if (jump && Grounded) {
			rb2d.AddRelativeForce (tf.transform.up * force);
		} else if (upleft && Grounded) {
			rb2d.AddRelativeForce (tf.transform.up * force);
			rb2d.AddRelativeForce (tf.transform.right * -force/4);
		} else if (upright && Grounded) {
			rb2d.AddRelativeForce (tf.transform.up * force);
			rb2d.AddRelativeForce (tf.transform.right * force/4);
		} 
	               }
}
