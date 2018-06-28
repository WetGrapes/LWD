using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceMove : MonoBehaviour {


	[SerializeField]float LowestPoint = 0f;
	GameObject Player;

	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");

	}

	void Update () {
		if (Player.transform.position.y < LowestPoint)
			LowestPoint = Player.transform.position.y;
		if (gameObject.transform.position.y >= LowestPoint) {
			float mult = (gameObject.transform.position - Player.transform.position).y
			             * (gameObject.transform.position - Player.transform.position).y;
			gameObject.transform.position -= new Vector3 (0, Time.deltaTime * 15 * mult, 0);
		}
	}
}
