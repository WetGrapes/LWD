using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GamePad : MonoBehaviour {

	public float endTime = 0.5f;
	public GameObject player; 
	private Player listOfBotton;

	void Start() {

		 listOfBotton = player.GetComponent<Player> ();

	}

	void OnMouseDown() {
	     
		switch (gameObject.name) {
		case "UpBotton":
			listOfBotton.up = true;
			break;
		case "LeftBotton":
			listOfBotton.left = true;
			break;
		case "RightBotton":
			listOfBotton.right = true;
			break;
		case "LeftUpBotton":
			listOfBotton.l_corner = true;
			break;
		case "RightUpBotton":
			listOfBotton.r_corner = true;
			break;
		case "CentralBotton":
			break;	
		}
	}

	void OnMouseUp(){

		 Invoke ("GetBool", endTime);
	
	}
	 
	void GetBool() {
		 
		switch (gameObject.name) {
		case "UpBotton":
			listOfBotton.up = false;
			break;
		case "LeftBotton":
			listOfBotton.left = false;
			break;
		case "RightBotton":
			listOfBotton.right = false;
			break;
		case "LeftUpBotton":
			listOfBotton.l_corner = false;
			break;
		case "RightUpBotton":
			listOfBotton.r_corner = false;
			break;	
		}

	}



}
