using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Generation : MonoBehaviour {
	public GameObject Counter;
	Counters Count;
	[Space]
	[SerializeField] GameObject[] Obs = new GameObject[5];
	[Space]
	[SerializeField] int MaxRnd = 500;
	[SerializeField] int MaxGround = 350;
	[SerializeField] int MaxSphere = 100;
	[SerializeField] int MaxEnemy = 60;
	[SerializeField] int MaxClock = 20;
	[SerializeField] int MaxBlb = 5;
	int[,] gm = new int[9,1500];
	int cl, rnd, lastClock, lastCrystal, lastEnemy;
	float xpos, ypos, size;
	public static int GenerationStage;

	[Space]
	public int LvlSide;
	public int StepOfGeneration;
	public int StartOfStep;
	bool GenDone;


	void Start () {
		Count = Counter.GetComponent<Counters> ();
		size = 1;
		xpos = -4 ;
		ypos = 2 ;
		StartCoroutine(StackGeneration ());
	}

	void Update()
	{
		if (GenDone) {
			if ((Count.NowLvlCounter*5) >= ((LvlSide * (StepOfGeneration + 1)) - (StartOfStep*5))) {
				GenDone = false;
				StepOfGeneration++;
				StartCoroutine (StackGeneration ());
			}
		}
	}


	IEnumerator StackGeneration()
	{
		yield return new WaitForSeconds (0.0001f);
		GenerationStage = 1;
		StartCoroutine(ArrayCreating ());
		yield return new WaitForSeconds (0.1f);
		GenerationStage = 2;
		StartCoroutine(ArrayArrangement ());
		yield return new WaitForSeconds (0.5f);
		GenerationStage = 3;
		GenDone = true;
		yield break;
	}

	IEnumerator ArrayCreating()
	{
		for (int i = (LvlSide*StepOfGeneration); i < (LvlSide*(StepOfGeneration+1)); i++) {
			yield return new WaitForSeconds (0.0001f);
			lastClock--;
			lastCrystal--;
			lastEnemy--;
			for (int j = 0; j < gm.GetLength (0); j++) {
				rnd = Random.Range (0, MaxRnd);
				if (j == 0 || j == gm.GetLength (0) - 1) {
					gm [j, i] = 1;
				} else {
					ArrayFilling (i, j);
					ArrayFixing (i, j);
					RemovalOfUnnecessaryElements (i, j);
				}
			}
		}
		yield break;
	}

	IEnumerator ArrayArrangement()
	{
		for (int i = (LvlSide*StepOfGeneration); i < (LvlSide*(StepOfGeneration+1)); i++) {
			yield return new WaitForSeconds (0.00f);
			for (int j = 0; j < gm.GetLength (0); j++) {
				if (Obs [gm [j, i]] != null) {
					Vector3 vc = new Vector3 (xpos, ypos, 0);
					GameObject ob = Instantiate (Obs [gm [j, i]], vc, Quaternion.identity) as GameObject;
				}
				xpos += size;
			}
			xpos = -4 * size;
			ypos -= size;
		}
		yield break;
	}

	void ArrayFilling(int i, int j)
	{
		if (gm [j, i] == 0) {
			if (rnd < MaxGround) {
				gm [j, i] = 1;
				cl++;
			}
			if (rnd < MaxSphere)
				gm [j, i] = 2;
			
			if (rnd < MaxEnemy && lastEnemy < 0) {
				gm [j, i] = 3;
				lastEnemy = 5;
				gm [j, i + 1] = 1;
				cl++;
			}
			if (rnd < MaxClock && lastClock < 0) {
				gm [j, i] = 4;
				lastClock = 10;
			}
			if (rnd < MaxBlb && lastCrystal < 0) {
				gm [j, i] = 5;
				lastCrystal = 50;
			}
		}
	}
	
	void ArrayFixing(int i, int j)
	{
		if (i > 0 && gm [j, (i - 1)] != 0) {
			if (i > 1 && gm [j, (i - 2)] != 0) {
				if ((j > 1 && gm [(j - 1), i] != 0)
					|| (j < gm.GetLength (0) - 2 && gm [(j + 1), i] != 0)) {
					gm [j, i] = 1;
					cl++;
				}
			}
		}
		if (i > 0 && gm [j, (i - 1)] == 1) {
			if ((j > 1 && gm [(j - 1), i] == 1)
				|| (j < gm.GetLength (0) - 2 && gm [(j + 1), i] == 1)) {
				gm [j, (i - 1)] = 0;
				cl++;
			}
		}
	}
	
	
	void RemovalOfUnnecessaryElements(int i, int j)
	{
		if (cl > 3) {
			gm [Random.Range (1, gm.GetLength (0)-1), i] = 0;
			gm [Random.Range (1, gm.GetLength (0)-1), i] = 0;
			cl = 0;
		}
	}
}

/*
 * Игра начинается
 * n = 25
 * k = 0
 * m = 5
 * Начало цикла
 * Генератор составляет массив на n*k>>n*(k+1) уровни
 * Генератор раставляет объекты на n*k>>n*(k+1) уровни
 * Генератор отключается?
 * Когда игрок достигает уровня (n*(k-1))-m, k++
 * Генератор включается?
 * Повтор пока 
 * 
 * */