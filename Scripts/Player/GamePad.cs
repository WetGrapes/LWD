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
				Invoke ("Off", 0.1f);
				break;
			case "LeftBotton":
				player.Left = true;
				break;
			case "RightBotton":
				player.Right = true;
				break;
			case "LeftUpBotton":
				player.UpLeft = true;
				Invoke ("Off", 0.1f);
				break;
			case "RightUpBotton":
				player.UpRight = true;
				Invoke ("Off", 0.1f);
				break;
			case "CentralBotton":
				player.Central = true; 
				break;
			}
		}
	}

	void OnMouseUp() {
		 
		switch (gameObject.name) {
	
		case "LeftBotton":
			player.Left = false;
			break;
		case "RightBotton":
			player.Right = false;
			break;

		}
	}

	void Off(){
		switch (gameObject.name) {
		case "UpBotton":
			player.Jump = false;
			break;
		case "LeftUpBotton":
			player.UpLeft = false;
			break;
		case "RightUpBotton":
			player.UpRight = false;
			break;
		}
	}


}
