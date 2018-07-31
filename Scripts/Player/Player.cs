using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[Space]
	public float Speed;
	public int DoubleJump;
	public int CentralTap;

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
	[Space]
	public int steps;
	public float seconds;


	void Start () {
		BodyPhysic = gameObject.GetComponent<Rigidbody2D> ();
		Way = gameObject.GetComponent<Trajectory> ();
		CountManager = Count.GetComponent<Counters> ();
		Particle = GetComponent<PlayerParticle> ();
		Jumper = GetComponent<PlayerJumper> ();
		StartCoroutine (Jumper.Play(Grounded, BodyPhysic));
		Debug.Log (LayerMask.LayerToName (8));

	}



	void FixedUpdate ()
	{
		Particle.IfNotGrounded (Grounded, Physics2D.OverlapPoint (new Vector2 (transform.position.x, transform.position.y - 0.8f), WhatIsGround));	
		Particle.SystemStart ();

		Grounded = Physics2D.OverlapCircle (GroundCheck.position, GroundRadius, WhatIsGround);

		
		if (Left && Grounded) {
			StartCoroutine (MoveToSide (-1,seconds, steps));
		} else if (Right && Grounded) {
			StartCoroutine (MoveToSide ( 1,seconds, steps));
		} 
		if (Central) {
			CentralTap++;
			if (Physics2D.OverlapPoint 
				(new Vector2 (transform.position.x, transform.position.y - 1), WhatIsGround) &&
				CountManager.blbCounter>0 && CentralTap == 2) 
			{
				Physics2D.OverlapPoint (new Vector2 (transform.position.x, transform.position.y - 1),
					WhatIsGround).gameObject.GetComponent<GroungAnimation> ().Deleting ();
				
				CountManager.blbCounter--;
				CentralTap = 0;
			}
			Central = false;

		}
	} 

	void Update () {
		if (Jump && Grounded) {
			DoubleJump = 2;
			Jump = false;
		} else if (UpLeft && Grounded) {
			if (UpFree()) {
				StartCoroutine (Move (1 + DoubleJump));
				UpLeft = false;
			} else 
				BodyPhysic.AddRelativeForce (transform.up * Force);
			DoubleJump = 0;
		} else if (UpRight && Grounded) {
			if (UpFree()) {
				StartCoroutine (Move (0 + DoubleJump));
				UpRight = false;
			} else 
				BodyPhysic.AddRelativeForce (transform.up * Force);
			DoubleJump = 0;
		} 
	}

	IEnumerator Move(int j) {
		CentralTap = 0;
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


	IEnumerator MoveToSide(int x, float time = 0.45f, int step = 5) {
		CentralTap = 0;
		if(!Physics2D.OverlapPoint(new Vector2(transform.position.x+x, transform.position.y), WhatIsGround))
		 {
			if (x > 0) {
				        Right = false;
			} else      Left  = false; 
				
			for(int i=0; i<step; i++) { 
				yield return new WaitForSeconds (Time.deltaTime * time);
				transform.position += new Vector3 ((float)x / (float)step, 0, 0);
			}
			yield return new WaitForSeconds (Time.deltaTime * time);
			yield break;
			}

	}
}