using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceMove : MonoBehaviour {

	[SerializeField]float LowestPoint = 0f;
	[SerializeField]float LowGo = 0f;
	[Space]
	[SerializeField]float Side = 2f;
	[SerializeField]float FinalMoveBlocks = 0f;
	[SerializeField]float PointMove = 0f;
	GameObject Player;
	[Space]
	public GameObject Manager;

	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		
		FinalMoveBlocks = Mathf.Sqrt(2f * Screen.height / Screen.width) / Side;
		PointMove = FinalMoveBlocks / 3f;
		gameObject.transform.position = new Vector3 (PointMove * Player.transform.position.x, 
			gameObject.transform.position.y, gameObject.transform.position.z);

		if (LowestPoint-1 <= 0)
			Manager.GetComponent<Counters> ().NowLvlCounter = ((int)(LowestPoint-1) * (-1))/5;
		

		if (Player.transform.position.y-LowGo < LowestPoint)
			LowestPoint = Player.transform.position.y-LowGo;

		if (gameObject.transform.position.y >= LowestPoint) {
			float mult = (gameObject.transform.position.y - (Player.transform.position.y-LowGo))
				* (gameObject.transform.position.y - (Player.transform.position.y-LowGo));
			gameObject.transform.position -= new Vector3 (0, Time.deltaTime * 15 * mult, 0);
		}
	}
}
