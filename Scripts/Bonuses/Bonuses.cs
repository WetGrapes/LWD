using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonuses : MonoBehaviour {
	public GameObject Player;
	public GameObject Manager;
	protected bool Tink = true;

	void Update () {
		if (Near()) {
			if (Tink)
				ActBonus ();
			Tink = false;
			Destroy (gameObject, 0.1f);
		}
	}
	bool Near () {
		return 
			(Mathf.Abs (Player.transform.position.x - transform.position.x) < 0.5f &&
			Mathf.Abs (Player.transform.position.y - transform.position.y) < 0.5f);
	}
	protected virtual void ActBonus()
	{
	}
}
