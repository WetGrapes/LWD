using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : INeedCam {
	
	public GameObject Counter;
	Counters Count;
	[Space]
	public Text txt;
	public int TimeCount;
	float timer = 1;



	protected override void WithStartAnother() {
		Count = Counter.GetComponent<Counters> ();
		TimeCount = 60;
	}
	

	void Update () {
		txt.text = TimeCount.ToString ();
		if (Cam.nowTarget == 2)
			TimeCount = Count.StartTime;
		if (Cam.nowTarget == 4) {
			if (timer >= 0)
				timer -= Time.deltaTime;
			else {
				timer = 1;
				TimeCount--;
				Count.SecondSpentCounter++;
			}
			if (TimeCount == 0) {
				Cam.nowTarget = 5;
			}
		}

	}
}
