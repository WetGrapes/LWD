using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateClick : TextToCamera  {

	[SerializeField][Range(0,3)] int State;
	protected override void WithStart()
	{}

	void OnMouseDown()
	{
		StateToCamera (State);
	}

}
