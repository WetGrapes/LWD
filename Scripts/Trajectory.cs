using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour {

	public GameObject Point;
	public DatasTrajectory[] Datas = new DatasTrajectory[3];
	public float Quan = 1.15f;
	[ContextMenu("trajectory")]
	void trajectory()
	{
		for( int j = 0; j< Datas.Length; j++)
			Datas [j].TrajectoryCalculating (Quan);
	}

	void Start()
	{ 
		for (int j = 0; j < Datas.Length; j++) {
			Datas [j].XCreate = Datas [j].StartXCreate;
			Datas [j].YCreate = Datas [j].StartYCreate;

			for (int i = 0; i < Datas [j].Steps; i++) {
				Datas [j].XCreate += Datas [j].XPoint [i];
				Datas [j].YCreate += Datas [j].YPoint [i];
				Datas [j].NewPoint [i] = Instantiate (Point, new Vector3 (Datas [j].XCreate, Datas [j].YCreate, -10), Quaternion.identity) as GameObject;
			}
			StartCoroutine (Cr (j));
		}
	}
	IEnumerator Cr(int j)
	{
		yield return new WaitForSeconds (0.2f);

		Datas [j].TrajectoryCalculating (Quan);
		StartCoroutine ( Cr(j));
		yield break;
	}
}
