using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePad : IClickableBotton {

	private Player player;
	public Player pp;

	void Start(){
		 player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

	}

	void OnMouseDown() {
		if (Check (4)) {
			switch (gameObject.name) {
			case "UpBotton":
				player.Jump = true;
				break;
			case "LeftBotton":
				player.Left = true;
				break;
			case "RightBotton":
				player.Right = true;
				break;
			case "LeftUpBotton":
				player.UpLeft = true;
				break;
			case "RightUpBotton":
				player.UpRight = true;
				break;
			case "CentralBotton":
				player.Central = true; 
				break;
			}

		}
	}

	void Send(string name)
	{
		if (gameObject.name == name + "Botton")
			;
		//3	player.
		
	}


}
