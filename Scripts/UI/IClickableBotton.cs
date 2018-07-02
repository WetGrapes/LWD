using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IClickableBotton : INeedCam {

	protected bool Check(int State)
	{
		FoundCam();
		bool ret;
		if (Cam.nowTarget == State)
			ret = true;
		else
			ret = false;
		return  ret;
	}
}
