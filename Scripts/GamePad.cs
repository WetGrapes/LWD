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
				player.jump = true;
				Invoke ("Off", 0.1f);
				break;
			case "LeftBotton":
				player.left = true;
				break;
			case "RightBotton":
				player.right = true;
				break;
			case "LeftUpBotton":
				player.upleft = true;
				Invoke ("Off", 0.1f);
				break;
			case "RightUpBotton":
				player.upright = true;
				Invoke ("Off", 0.1f);
				break;
			case "CentralBotton":
				player.central = true; 
				break;
			}
		}
	}

	void OnMouseUp() {
		 
		switch (gameObject.name) {
	
		case "LeftBotton":
			player.left = false;
			break;
		case "RightBotton":
			player.right = false;
			break;

		}
	}

	void Off(){
		switch (gameObject.name) {
		case "UpBotton":
			player.jump = false;
			break;
		case "LeftUpBotton":
			player.upleft = false;
			break;
		case "RightUpBotton":
			player.upright = false;
			break;
		}
	}


}
