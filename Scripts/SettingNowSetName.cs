using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingNowSetName : MonoBehaviour {
	GroundAnimator Animator;
	Text txt;
	void Start () {
		Animator = GameObject.Find("GroundAnimator").GetComponent<GroundAnimator> ();
		txt = GetComponent<Text> ();
	}

	public void SetText()
	{
		if (Animator!= null && txt != null)
			txt.text = Animator.Sets [Animator.NowSet].Name;
	}
}
