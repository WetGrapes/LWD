using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTopAndToStage :ToTop {
	[SerializeField][Range(0,5)] int State = 0;
	protected override void MoveCameraAndState ()
	{
		Cam.nowTarget = State;
	}
}
