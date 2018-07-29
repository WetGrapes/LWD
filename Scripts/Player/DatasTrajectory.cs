using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DatasTrajectory {
	public GameObject[] NewPoint = new GameObject[5];
	[Space]
	public float[] XPoint = new float[5];
	public float[] YPoint = new float[5];
	[Space]
	public int Steps = 5;
	public float Lenght = 1;
	public float XMult = 1;
	public float YMult = 1;
	[Space]
	[System.NonSerialized] public float OneStep = 0;
	[System.NonSerialized] public float QuanMultip = 1;
	[System.NonSerialized] public float FinalX;
	[System.NonSerialized] public float FinalY;
	[System.NonSerialized] public float XCreate, YCreate;
	[Space]
	public float StartXCreate;
	public float StartYCreate;

	public void TrajectoryCalculating(float Quan)
	{
		QuanMultip = 1;
		for (int i = 0; i < Steps; i++)
			QuanMultip *= Quan;  //множитель в степени

		OneStep = 0;
		OneStep = ((Quan - 1) * Lenght) / (QuanMultip - 1);// формула первого элемента

		XPoint [0] = OneStep * XMult;    // первая точка х
		YPoint [Steps - 1] =OneStep * YMult;  // последняя точка у

		FinalX = XPoint [0];
		FinalY = YPoint [Steps - 1];
		XCreate = StartXCreate;
		YCreate = StartYCreate;


		for (int i = 1; i < Steps; i++)
		{

			XPoint [i] = XPoint [i - 1] * Quan;
			FinalX += XPoint[i];

			YPoint [Steps - 1 - i] = YPoint [Steps - i] * Quan;
			FinalY += YPoint [Steps - 1 - i];

			XCreate += XPoint [i-1];
			YCreate += YPoint [i-1];
			NewPoint [i-1].transform.position = new Vector3 (XCreate, YCreate, -10);
		}
		XCreate += XPoint [Steps - 1];
		YCreate += YPoint [Steps - 1];
		NewPoint [Steps - 1].transform.position = new Vector3 (XCreate, YCreate, -10);
	}
}
