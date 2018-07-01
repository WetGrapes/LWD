using System.Collections;
using System.Collections.Generic;
//using System.Reflection;
using UnityEngine;

public class StateClick : INeedCam   {
	
	
	[SerializeField][Range(0,4)] int State = 0;

	void OnMouseDown()
	{
		
		StateToCamera (State);
	}

}
