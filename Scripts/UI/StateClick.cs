using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateClick : INeedCam   {
	
	
	[SerializeField][Range(0,5)] int State = 0;

	void OnMouseDown()
	{
		
		StateToCamera (State);
	}

}
