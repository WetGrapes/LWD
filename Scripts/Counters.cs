using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Counters : INeedCam {
	public int blbCounter;
	[Space]
	public int BallSphereCounter;
	public int LevelSphereCounter;
	[Space]
	public int MaxLvlCounter;
	public int NowLvlCounter;
	[Space]
	public int SecondSpentCounter;
	public int AllSecondSpentCounter;
	[Space]
	public int StartTime;
	public int ClockTime;
	public int EnemyTime;
	[Space]
	public Text SphereText;
	public Text EndSphereText;
	public Text X2SphereText;
	public Text BallSphereMainText;
	[Space]
	public Text SecondsSpentText;
	public Text AllSecondsSpentText;
	[Space]
	public Text CrystalText;
	[Space]
	public Text MaxLevelText;
	public Text NowLevelText;
	public Text NowLvlText;


	void Update()
	{
		SphereText.text = LevelSphereCounter.ToString ();
		EndSphereText.text = LevelSphereCounter.ToString ();
		X2SphereText.text = (LevelSphereCounter * 2).ToString ();
		BallSphereMainText.text = BallSphereCounter.ToString ();

		SecondsSpentText.text = SecondSpentCounter.ToString () + " seconds spent";
		AllSecondsSpentText.text = AllSecondSpentCounter.ToString ();

		CrystalText.text = blbCounter.ToString ();

		NowLvlText.text = NowLvlCounter.ToString ();
		NowLevelText.text = "Level \n" + NowLvlCounter.ToString ();
		MaxLevelText.text = "Maximal Level " + MaxLvlCounter.ToString ();

		if (MaxLvlCounter < NowLvlCounter)
			MaxLvlCounter = NowLvlCounter;	


		if (Cam.nowTarget != 4 && Cam.nowTarget != 5) {
			NowLvlCounter = 0;
			BallSphereCounter += LevelSphereCounter;
			AllSecondSpentCounter += SecondSpentCounter;
			SecondSpentCounter = 0;
			LevelSphereCounter = 0;
		}
	}
}
