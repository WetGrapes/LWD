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
	PlayerJumper Jumper;
	[Space]
	PlayerParticle Particle;


	void Start () {
		BodyPhysic = gameObject.GetComponent<Rigidbody2D> ();
		Way = gameObject.GetComponent<Trajectory> ();
		CountManager = Count.GetComponent<Counters> ();
		Particle = GetComponent<PlayerParticle> ();
		Jumper = GetComponent<PlayerJumper> ();
		StartCoroutine (Jumper.Play(Grounded, BodyPhysic));
	}



	void FixedUpdate ()
	{
		Particle.IfNotGrounded (Grounded, Physics2D.OverlapPoint (new Vector2 (transform.position.x, transform.position.y - 0.6f), WhatIsGround));	
		Particle.SystemStart (0.5f);

		Grounded = Physics2D.OverlapCircle (GroundCheck.position, GroundRadius, WhatIsGround);

		
		if (Left) {
			StartCoroutine (MoveToSide (-1));
			//BodyPhysic.velocity = new Vector2 (-Speed, BodyPhysic.velocity.y);
		} else if (Right) {
			StartCoroutine (MoveToSide (1));
			//BodyPhysic.velocity = new Vector2 (Speed, BodyPhysic.velocity.y);
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
			DoubleJump = 0;
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
		//проверка места куда он должен попасть
		if (!Physics2D.OverlapPoint
		(new Vector2 (GroundCheck.position.x + Way.Datas [j].FinalX, GroundCheck.position.y + Way.Datas [j].FinalY),
			   WhatIsGround)) 
		{
			//физика отключается (чтобы он не падал во время выполнения скрипта)
			BodyPhysic.simulated = false;

			//цикл передвижения по точкам
			for (int i = 0; i < Way.Datas [j].Steps; i++) {
				//так как цикл расчитывается моментально(а тут нам это не нужно) мы делаем задержку
				yield return new WaitForSeconds (Time.deltaTime * 0.8f);

				//вот это перемещение на следующую точку
				transform.position = new Vector3 (transform.position.x + Way.Datas [j].XPoint [i], 
					transform.position.y + Way.Datas [j].YPoint [i], 
					transform.position.z);
			}

			//физика включается, объект уже на позиции
			BodyPhysic.simulated = true;
		} else 
			//если позиция куда должен сдвинуться игрок занята, то он немного подпрыгивает, чтобы было понятно, что кнопка нажалась
			BodyPhysic.AddRelativeForce (transform.up * Force);
		//останавливаем энумератор, иначе он уйдет в вечный цикл
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
    
	IEnumerator MoveToSide(int x) {
		if (x < 0) {
			transform.position += new Vector3 (-1, 0, 0);
			Left = false;  
			yield return new WaitForSeconds (Time.deltaTime * 0.8f);
		} else {
			transform.position += new Vector3 (1, 0, 0);
			Right = false;  
			yield return new WaitForSeconds (Time.deltaTime * 0.8f);
		}
	}

}